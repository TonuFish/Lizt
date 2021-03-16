using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Lizt.Extensions;
using System;

namespace Lizt.Benchmarks.FindIndex
{
    // dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'Disassembly'

    [DisassemblyDiagnoser(printSource: true, printInstructionAddresses: true, exportHtml: true, exportCombinedDisassemblyReport: true, exportDiff: true)]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp50, id: "net5.0")]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31, id: "net3.1")]
    public class Disassembly
    {
        private int _iterations = 1_000_000;
        private byte[] _source;

        [Params(1_024)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _source = new byte[N];
            var rand = new Random(0);
            for (int ii = 0 ; ii < _source.Length ; ii++)
            {
                _source[ii] = (byte)rand.Next(0, byte.MaxValue - 1);
            }
            _source[N - 1] = byte.MaxValue;
        }

        [Benchmark]
        public int Lizt()
        {
            int result = int.MinValue;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = _source.FindIndex(byte.MaxValue);
            }

            return result;
        }
    }
}
