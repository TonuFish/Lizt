using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Attributes;
using System;
using Lizt.Extensions;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Configs;

namespace Lizt.Benchmarks.FindIndex
{
    // dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_UInt16'

    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp50, id: "net5.0")]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31, id: "net3.1")]
    [AsciiDocExporter, CsvExporter, HtmlExporter, JsonExporter(indentJson: true), MarkdownExporter, XmlExporter(indentXml: true)]
    [RPlotExporter, CsvMeasurementsExporter] // For R graphs
    [AllStatisticsColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class Array_UInt16
    {
        private uint _iterations = 5_000_000;
        private UInt16[] _source;

        [Params(128, 256, 512, 1_024, 2_048, 4_096)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _source = new UInt16[N];
            var rand = new Random(765);
            for (int ii = 0 ; ii < _source.Length ; ii++)
            {
                _source[ii] = (UInt16)rand.Next(0, UInt16.MaxValue - 1);
            }
            _source[N - 1] = UInt16.MaxValue;
        }

        [Benchmark]
        public int Lizt_FindIndex()
        {
            int result = -1;

            for (uint ii = 0 ; ii < _iterations ; ii++)
            {
                result = _source.FindIndex(UInt16.MaxValue);
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public int SpanHelpers_IndexOf()
        {
            int result = -1;

            for (uint ii = 0 ; ii < _iterations ; ii++)
            {
                result = Array.IndexOf<UInt16>(_source, UInt16.MaxValue);
            }

            return result;
        }
    }
}
