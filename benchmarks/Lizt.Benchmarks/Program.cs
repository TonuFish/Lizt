using BenchmarkDotNet.Running;
using System;

namespace Lizt.Benchmarks
{
    static class Program
    {
        // TODO: Do this properly, CommandLineParser or setup benches to use BenchmarkDotNet tooling
        // TODO: Re-write the benches to not be a copy-paste in a rush mess

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Need args.");
            }

            switch (args[0])
            {
                case "ArrayBenchmark":
                    BenchmarkRunner.Run<FindIndex.ArrayBenchmark>();
                    break;
                case "ArrayBenchmarkInt":
                    BenchmarkRunner.Run<FindIndex.ArrayBenchmarkInt>();
                    break;
                case "Disassembly":
                    BenchmarkRunner.Run<FindIndex.Disassembly>();
                    break;
                case "Etw":
                    BenchmarkRunner.Run<FindIndex.Etw>();
                    break;
                case "Inlining":
                    BenchmarkRunner.Run<FindIndex.Inlining>();
                    break;
                case "SortedIntBenchmark":
                    BenchmarkRunner.Run<FindIndex.SortedIntBenchmark>();
                    break;
                case "UnsortedByteBenchmark":
                    BenchmarkRunner.Run<FindIndex.UnsortedByteBenchmark>();
                    break;
                case "UnsortedShortBenchmark":
                    BenchmarkRunner.Run<FindIndex.UnsortedShortBenchmark>();
                    break;
                case "UnsortedIntBenchmark":
                    BenchmarkRunner.Run<FindIndex.UnsortedIntBenchmark>();
                    break;
                case "UnsortedDoubleBenchmark":
                    BenchmarkRunner.Run<FindIndex.UnsortedDoubleBenchmark>();
                    break;
                default:
                    throw new ArgumentException("Bad args.");
            }
        }
    }
}
