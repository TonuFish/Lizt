using Microsoft.CodeAnalysis;
using System;
using System.Text;

namespace Lizt.Generators
{
    [Generator]
    public class FindIndexGenerator : ISourceGenerator
    {
        private const string HintName = "Lizt.Generated.FindIndex.g.cs";
        private const int NotFoundValue = -1;

        // TODO: Engineer this a bit more... Dictionary<struct>(128|256, type), struct containing method strings
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

            var sb = new StringBuilder(capacity: 100_000); // 99,836 total

            GenerateClassHeader(sb);
            GenerateFields(sb);

            foreach (var type in _hardwareTypes)
            {
                foreach (var name in _sourceArgumentNames)
                {
                    GenerateFindIndexMethod(sb, type, name);
                }
            }

            // Remove spacing newline from last method group
            sb.Length -= System.Environment.NewLine.Length;

            GenerateClassFooter(sb);

            // Generate file please
            context.AddSource(HintName, sb.ToString());
        }

#region Generation

        private void GenerateClassHeader(StringBuilder sb)
        {
            // TODO: Use NuGet/assembly? version for GeneratedCodeAttribute version
            sb.Append(
@"using System;
using System.CodeDom.Compiler;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Lizt.Generated.FindIndex
{
    [GeneratedCodeAttribute(""LiztFindIndexGenerator"", ""0.7.0-alpha"")]
    internal static class Gen
    {
");
        }

        private void GenerateFields(StringBuilder sb)
        {
            sb.Append(
$@"        private const int NotFound = {NotFoundValue};

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
            if (startIndex < 0 || startIndex >= {sourceArgumentName}.Length)
            {{ throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, ""Starting index was out of range. It must be non-negative and less than the length of the source.""); }}
            if (count < 1 || startIndex + count > {sourceArgumentName}.Length)
            {{ throw new ArgumentOutOfRangeException(nameof(count), count, ""Count was out of range. It must be positive and not cause iteration outside the bounds of the source.""); }}

            var endIndex = startIndex + count;
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
             * There's no wrapper for CompareEqual->Compare using float or double arguments under .NET Core.
             * 
             * .NET 5 CompareEqual: "The above native signature does not exist. We provide this additional overload for completeness."
             * Doc: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.x86.avx.compareequal?view=net-5.0
             * Impementation: https://source.dot.net/#System.Private.CoreLib/Avx.cs,0fb121b6f85b7c70
             * 
             * t.f. compareEqual256core uses the above implementation manually.
             */

            string instructionSet256, compareEqual256, compareEqual256core;
            string moveMask256, tzcnt256;
            if (type is "Single" or "Double")
            {
                instructionSet256 = "Avx";
                compareEqual256 = "Avx.CompareEqual(targetVector, loopVector);";
                compareEqual256core = "Avx.Compare(targetVector, loopVector, FloatComparisonMode.OrderedEqualNonSignaling);";

                // MoveMask supports float and double as parameters, so no extra handling is required
                moveMask256 = "Avx.MoveMask(matchVector);";
                tzcnt256 = "BitOperations.TrailingZeroCount(moveMask);";
            }
            else
            {
                instructionSet256 = "Avx2";

                /* CompareEqual returns a Vector256<T> with all bits set where the input vectors match.
                 * 
                 * For example, the below Int64 comparison:
                 * param1: <  0,  9,  4,  9  >
                 * param2: <  9,  9,  9,  9  >
                 * return: <  0, -1,  0, -1  >
                 */
                compareEqual256 = "Avx2.CompareEqual(targetVector, loopVector);";
                compareEqual256core = "Avx2.CompareEqual(targetVector, loopVector);";

                moveMask256 = type is "Byte" or "SByte"
                    ? "Avx2.MoveMask(matchVector);"
                    : $"Avx2.MoveMask(Unsafe.As<Vector256<{type}>, Vector256<Byte>>(ref matchVector));";

                /* Tzcnt must account for the cast to byte used in MoveMask.
                 * 
                 * For example; if an int match is found in position 7 (of 0:7), CompareEqual returns:
                 * <0, 0, 0, 0, 0, 0, 0, -1>
                 * 
                 * As MoveMask doesn't have an int overload, it is easiest to re-interpret the result as bytes.
                 * Hence, it now appears as if CompareEqual found 4 matches, at 28, 29, 30, 31 (of 0:31)
                 * <0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1>
                 * 
                 * MoveMask interprets this as (int) -268435456, byte representation:
                 * 1111_0000_0000_0000_0000_0000_0000_0000
                 * 
                 * TrailingZeroCount correctly returns 28.
                 * Dividing this by the byte width of int returns the correct offset (28 / 4 = 7)
                 */
                tzcnt256 = $"(BitOperations.TrailingZeroCount(moveMask) / sizeof({type}));";
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
#if NET5_0_OR_GREATER
                        Vector256<{type}> matchVector = {compareEqual256}
#else
                        Vector256<{type}> matchVector = {compareEqual256core}
#endif
                        int moveMask = {moveMask256}

                        if (moveMask != 0)
                        {{
                            return index + {tzcnt256}
                        }}
                        else
                        {{
                            index += Vector256<{type}>.Count;
                        }}
                    }}
                }}
");

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

            var compareEqual128 = $"{instructionSet128}.CompareEqual(targetVector, loopVector);";

            string moveMask128, tzcnt128;
            if (type is "Single" or "Double")
            {
                moveMask128 = type is "Single" ? "Sse.MoveMask(matchVector);" : "Sse2.MoveMask(matchVector);";
                tzcnt128 = "BitOperations.TrailingZeroCount(moveMask);";
            }
            else
            {
                moveMask128 = type is "Byte" or "SByte"
                    ? "Sse2.MoveMask(matchVector);"
                    : $"Sse2.MoveMask(Unsafe.As<Vector128<{type}>, Vector128<Byte>>(ref matchVector));";
                // Refer to explanation above tzcnt256
                tzcnt128 = $"(BitOperations.TrailingZeroCount(moveMask) / sizeof({type}));";
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
                            return index + {tzcnt128}
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

            // Default return, release pin and close method
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
