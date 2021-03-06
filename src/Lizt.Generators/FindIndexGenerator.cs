using Microsoft.CodeAnalysis;
using System;
using System.Text;

namespace Lizt.Generators
{
    [Generator]
    public class FindIndexGenerator : ISourceGenerator
    {
#if NET5_0_OR_GREATER
        private const string HintName = "Lizt.Generated.FindIndex.g5.cs";
#else
        private const string HintName = "Lizt.Generated.FindIndex.g31.cs";
#endif
        // TODO: See if there's a performance hit to changing this structure to something more
        // engineered (instead of a bunch of strings)
        private static readonly string[] _hardwareTypes = new string[]
        {
            "Byte",
            "SByte",
            "Double",
            "Int16",
            "Int32",
            "Int64",
            "Single",
            "UInt16",
            "UInt32",
            "UInt64",
        };
        private static readonly string[] _sourceArgumentNames = new string[]
        {
            "array",
            "span",
            "readOnlySpan",
        };

        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            //! Comment these debugger methods to debug
            //System.Diagnostics.Debugger.Launch();
            //System.Diagnostics.Debugger.Break();

            // TODO: Refine capacity after final generation
            var sb = new StringBuilder(capacity: 180_000);

            GenerateClassHeader(sb);
            GenerateFields(sb);
            GenerateSharedMethods(sb);

            foreach (var type in _hardwareTypes)
            {
                foreach (var name in _sourceArgumentNames)
                {
                    GenerateFindIndexMethod(sb, type, name);
                }
            }

            // TODO: Remove these test methods
            //GenerateFindIndexMethod(sb, "Byte", "span");
            //GenerateFindIndexMethod(sb, "Single", "span");
            //GenerateFindIndexMethod(sb, "Double", "span");

            // Remove spacing newline from method group
            sb.Length -= System.Environment.NewLine.Length;

            GenerateClassFooter(sb);

            // Generate this code please
            context.AddSource(HintName, sb.ToString());
        }

#region Generation

        private void GenerateClassHeader(StringBuilder sb)
        {
            // TODO: Use NuGet/assembly? version for GeneratedCodeAttribute version
            sb.Append(
@"using System;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Lizt.Generated.FindIndex
{
    [GeneratedCodeAttribute(""LiztFindIndexGenerator"", ""0.7.0"")]
    public static class Gen
    {
");
        }

        private void GenerateFields(StringBuilder sb)
        {
            sb.Append(
@"        private const int NotFound = -1;
        private const int Vec128MoveMaskOffset = 16;
");
        }

        private void GenerateSharedMethods(StringBuilder sb)
        {
            sb.Append(
@"
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int ParseOffsetFromMoveMask(int moveMask, int typeSize)
        {
            var shiftCount = 0;
            while (moveMask > 1)
            {
                moveMask >>= typeSize;
                ++shiftCount;
            }

            return shiftCount;
        }

");
        }

        private void GenerateFindIndexMethod(StringBuilder sb, string type, string sourceArgumentName)
        {
            var signature = sourceArgumentName switch
            {
                "array"        => $"        public static unsafe int FindIndex({type}[] {sourceArgumentName}, {type} value, int startIndex, int count)",
                "span"         => $"        public static unsafe int FindIndex(Span<{type}> {sourceArgumentName}, {type} value, int startIndex, int count)",
                "readOnlySpan" => $"        public static unsafe int FindIndex(ReadOnlySpan<{type}> {sourceArgumentName}, {type} value, int startIndex, int count)",
                _              => throw new ArgumentException($"No matching FindIndex signature for {nameof(type)}: {type}", nameof(type)),
            };

            // Method signature
            sb.Append(signature);

            // Validation and looping indexes
            sb.Append(
$@"
        {{
            if (startIndex < 0)
            {{ throw new ArgumentException($""{{nameof(startIndex)}} must be a non-negative integer."", nameof(startIndex)); }}
            if (count < 1)
            {{ throw new ArgumentException($""{{nameof(count)}} must be greater or equal to 1."", nameof(count)); }}
            if ({sourceArgumentName}.Length == 0)
            {{ return NotFound; }}

            var endIndex = startIndex + count < {sourceArgumentName}.Length
                ? startIndex + count
                : {sourceArgumentName}.Length;
            var index = startIndex;
");

            // Unsafe, pin source in memory
            sb.Append(
$@"
            fixed ({type}* bufferPtr = {sourceArgumentName})
            {{");

            // Vector256 (Avx+) implementation

            /* Vector256<T> instruction set map
             * 
             * |  Type  | Load | CompareEqual | MoveMask | Minimum Set |
             * | ------ | ---- | ------------ | -------- | ----------- |
             * | byte   | Avx  |    Avx2      |   Avx2   |    Avx2     |
             * | sbyte  | Avx  |    Avx2      |   Avx2   |    Avx2     |
             * | short  | Avx  |    Avx2      |          |    Avx2     |
             * | ushort | Avx  |    Avx2      |          |    Avx2     |
             * | int    | Avx  |    Avx2      |          |    Avx2     |
             * | uint   | Avx  |    Avx2      |          |    Avx2     |
             * | long   | Avx  |    Avx2      |          |    Avx2     |
             * | ulong  | Avx  |    Avx2      |          |    Avx2     |
             * | float  | Avx  |    Avx       |   Avx    |    Avx      |
             * | double | Avx  |    Avx       |   Avx    |    Avx      |
             * 
             * Exception (.NET Core 3.x)
             * There's no support for CompareEqual using float or double arguments under .NET Core,
             * therefore Vector256's cannot be used.
             * Not sure why, but it's inconvenient.
             */

            /*
             * 256
             * Single : 128, 64, 32, 16, 8, 4, 2, 1 = -24
             * Double : 8, 4, 2, 1 = -28
             * 128
             * Single : 8, 4, 2, 1 = -28
             * Double : 2, 1 = -30
             */

#if !NET5_0_OR_GREATER
            if (type is not ("Single" or "Double"))
            {
#endif

            string instructionSet256, compareEqual256;
            string moveMask256, lzcntAction256, tzcntAction256, defaultAction256;
            if (type is "Single" or "Double")
            {
                instructionSet256 = "Avx";
#if !NET5_0_OR_GREATER
                compareEqual256 = @"Vector256<Single>.Zero;
throw new Exception(); // If you have hit this line, something has gone very wrong";
#else
                compareEqual256 = $@"Avx.CompareEqual(targetVector, loopVector);";
#endif

                moveMask256 = @"Avx.MoveMask(matchVector);";
                lzcntAction256 = $@"(int)Lzcnt.LeadingZeroCount((uint)moveMask) - {(type is "Single" ? "24" : "28")};";
                tzcntAction256 = @"(int)Bmi1.TrailingZeroCount((uint)moveMask);";
                defaultAction256 = $@"ParseOffsetFromMoveMask(moveMask, 1);";
            }
            else
            {
                instructionSet256 = "Avx2";
                compareEqual256 = $@"Avx2.CompareEqual(targetVector, loopVector);";

                moveMask256 = type is "Byte" or "SByte"
                    ? @"Avx2.MoveMask(matchVector);"
                    : $@"Avx2.MoveMask(Unsafe.As<Vector256<{type}>, Vector256<Byte>>(ref matchVector));";
                lzcntAction256 = $@"Vector256<{type}>.Count - ((int)Lzcnt.LeadingZeroCount((uint)moveMask) / sizeof({type})) - 1;";
                tzcntAction256 = $@"(int)Bmi1.TrailingZeroCount((uint)moveMask) / sizeof({type});";
                defaultAction256 = $@"ParseOffsetFromMoveMask(moveMask, sizeof({type}));";
            }

            sb.Append(
$@"
                if ({instructionSet256}.IsSupported && endIndex - index >= Vector256<{type}>.Count)
                {{
                    var terminatingIndex = endIndex - ((endIndex - index) % Vector256<{type}>.Count);
                    Vector256<{type}> targetVector = Vector256.Create(value);

                    while (index < terminatingIndex)
                    {{
                        Vector256<{type}> loopVector = Avx.LoadVector256(bufferPtr + index);
                        Vector256<{type}> matchVector = {compareEqual256}
                        int moveMask = {moveMask256}

                        if (moveMask != 0)
                        {{
                            if (Lzcnt.IsSupported)
                            {{
                                return {lzcntAction256}
                            }}
                            else if (Bmi1.IsSupported)
                            {{
                                return {tzcntAction256}
                            }}
                            else
                            {{
                                return {defaultAction256}
                            }}
                        }}
                        else
                        {{
                            index += Vector256<{type}>.Count;
                        }}
                    }}
                }}
");
#if !NET5_0_OR_GREATER
            }
#endif

            // Vector128 (Sse+) implementation

            /* Vector128<T> instruction set map
             * 
             * |  Type  | Load | CompareEqual | MoveMask | Minimum Set |
             * | ------ | ---- | ------------ | -------- | ----------- |
             * | byte   | Sse2 |    Sse2      |   Sse2   |    Sse2     |
             * | sbyte  | Sse2 |    Sse2      |   Sse2   |    Sse2     |
             * | short  | Sse2 |    Sse2      |          |    Sse2     |
             * | ushort | Sse2 |    Sse2      |          |    Sse2     |
             * | int    | Sse2 |    Sse2      |          |    Sse2     |
             * | uint   | Sse2 |    Sse2      |          |    Sse2     |
             * | long   | Sse2 |    Sse41     |          |    Sse41    |
             * | ulong  | Sse2 |    Sse41     |          |    Sse41    |
             * | float  | Sse  |    Sse       |   Sse    |    Sse      |
             * | double | Sse2 |    Sse2      |   Sse2   |    Sse2     |
            */

            var instructionSet128 = type switch
            {
                "Int64" or "UInt64" => "Sse41",
                "Single" => "Sse",
                _ => "Sse2"
            };

            var compareEqual128 = $@"{instructionSet128}.CompareEqual(targetVector, loopVector);";

            string moveMask128, lzcntAction128, tzcntAction128, defaultAction128;
            if (type is "Single" or "Double")
            {
                moveMask128 = type is "Single" ? @"Sse.MoveMask(matchVector);" : @"Sse2.MoveMask(matchVector);";
                lzcntAction128 = $@"(int)Lzcnt.LeadingZeroCount((uint)moveMask) - {(type is "Single" ? "28" : "30")};";
                tzcntAction128 = @"(int)Bmi1.TrailingZeroCount((uint)moveMask);";
                defaultAction128 = $@"ParseOffsetFromMoveMask(moveMask, 1);";
            }
            else
            {
                moveMask128 = type is "Byte" or "SByte"
                    ? @"Sse2.MoveMask(matchVector);"
                    : $@"Sse2.MoveMask(Unsafe.As<Vector128<{type}>, Vector128<Byte>>(ref matchVector));";
                lzcntAction128 = $@"Vector128<{type}>.Count - ((int)Lzcnt.LeadingZeroCount((uint)moveMask) / sizeof({type})) - 1 - Vec128MoveMaskOffset;";
                tzcntAction128 = $@"(int)Bmi1.TrailingZeroCount((uint)moveMask) / sizeof({type});";
                defaultAction128 = $@"ParseOffsetFromMoveMask(moveMask, sizeof({type}));";
            }

            sb.Append(
$@"
                if ({instructionSet128}.IsSupported && endIndex - index >= Vector128<{type}>.Count)
                {{
                    var terminatingIndex = endIndex - ((endIndex - index) % Vector128<{type}>.Count);
                    Vector128<{type}> targetVector = Vector128.Create(value);

                    while (index < terminatingIndex)
                    {{
                        Vector128<{type}> loopVector = Sse2.LoadVector128(bufferPtr + index);
                        Vector128<{type}> matchVector = {compareEqual128}
                        int moveMask = {moveMask128}

                        if (moveMask != 0)
                        {{
                            if (Lzcnt.IsSupported)
                            {{
                                return {lzcntAction128}
                            }}
                            else if (Bmi1.IsSupported)
                            {{
                                return {tzcntAction128}
                            }}
                            else
                            {{
                                return {defaultAction128}
                            }}
                        }}
                        else
                        {{
                            index += Vector128<{type}>.Count;
                        }}
                    }}
                }}
");

            // Manual loop implementation
            sb.Append(
@"
                for (; index < endIndex ; index++)
                {
                    if (*(bufferPtr + index) == value)
                    {
                        return index;
                    }
                }
");

            // Default return, close pin and method
            sb.Append(
@"
                return NotFound;
            }
        }

");
        }

        private void GenerateClassFooter(StringBuilder sb)
        {
            sb.Append(
@"    }
}
");
        }

#endregion Generation
    }
}
