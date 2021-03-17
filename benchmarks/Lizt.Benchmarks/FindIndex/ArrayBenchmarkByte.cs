using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Attributes;
using System;
using Lizt.Extensions;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Configs;

namespace Lizt.Benchmarks.FindIndex
{
    // dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'ArrayBenchmarkByte'

    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp50, id: "net5.0")]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31, id: "net3.1")]
    [AsciiDocExporter, CsvExporter, HtmlExporter, JsonExporter(indentJson: true), MarkdownExporter, XmlExporter(indentXml: true)]
    [RPlotExporter, CsvMeasurementsExporter] // For R graphs
    [AllStatisticsColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class ArrayBenchmarkByte
    {
        private int _iterations = 15_000_000;
        private byte[] _source;

        [Params(128, 256, 512, 1_024, 2_048, 4_096)]
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

//        [Benchmark]
//        public int InfraOverhead()
//        {
//            int result = -1;

//            for (int ii = 0 ; ii < _iterations ; ii++)
//            { }

//            return result;
//        }

        [Benchmark]
        public int Lizt_FindIndex()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = _source.FindIndex(byte.MaxValue);
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public int SpanHelpers_IndexOf()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = Array.IndexOf<byte>(_source, byte.MaxValue);
            }

            return result;
        }
    }
}
