using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;

namespace Lizt.Benchmarks
{
    static class Program
    {
        // TODO: Do this properly, CommandLineParser or setup benches to use BenchmarkDotNet tooling

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Takes 2 arg: {Method} {Benchmark}");
            }

            var config = ManualConfig.Create(DefaultConfig.Instance)
                .WithOption(ConfigOptions.DontOverwriteResults, true);

            var typeString = $"Lizt.Benchmarks.{args[0].Trim()}.{args[1].Trim()}";
            var type = Type.GetType(typeString);
            if (type == null)
            {
                throw new ArgumentException($"Invalid benchmark name: {typeString}");
            }

            BenchmarkRunner.Run(Type.GetType(typeString), config);
        }
    }
}
