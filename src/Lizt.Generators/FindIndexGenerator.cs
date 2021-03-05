using Microsoft.CodeAnalysis;
using System.Text;

namespace Lizt.Generators
{
    [Generator]
    public class FindIndexGenerator : ISourceGenerator
    {
        private const string HintName = "FindIndex.generated.cs";
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

        public void Initialize(GeneratorInitializationContext context)
        {
            throw new System.NotImplementedException(); // TODO: Remove this once implemented
        }

        public void Execute(GeneratorExecutionContext context)
        {
            throw new System.NotImplementedException(); // TODO: Remove this once implemented

            // Comment these in to debug
            //System.Diagnostics.Debugger.Launch();
            //System.Diagnostics.Debugger.Break();

            // TODO: Calculate max size for this method
            var sb = new StringBuilder(capacity: 1000, value:
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

            // Start
            // Fields
            // Shared methods
            // foreach type
            // - foreach source
            // End

        }

        private void GenerateClassHeader(StringBuilder sb)
        {

        }

        private void GenerateFields(StringBuilder sb)
        {

        }

        private void GenerateSharedMethods(StringBuilder sb)
        {

        }

        private void GenerateFindIndex(StringBuilder sb)
        {

        }
    }
}
