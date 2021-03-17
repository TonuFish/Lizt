using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Attributes;
using System;
using Lizt.Extensions;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Configs;

namespace Lizt.Benchmarks.FindIndex
{
    // dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_SByte'

    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp50, id: "net5.0")]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31, id: "net3.1")]
    [AsciiDocExporter, CsvExporter, HtmlExporter, JsonExporter(indentJson: true), MarkdownExporter, XmlExporter(indentXml: true)]
    [RPlotExporter, CsvMeasurementsExporter] // For R graphs
    [AllStatisticsColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class Array_SByte
    {
        private uint _iterations = 15_000_000;
        private SByte[] _source;

        [Params(128, 256, 512, 1_024, 2_048, 4_096)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _source = new SByte[N];
            var rand = new Random(765);
            for (int ii = 0 ; ii < _source.Length ; ii++)
            {
                _source[ii] = (SByte)rand.Next(0, SByte.MaxValue - 1);
            }
            _source[N - 1] = SByte.MaxValue;
        }

        [Benchmark]
        public int Lizt_FindIndex()
        {
            int result = -1;

            for (uint ii = 0 ; ii < _iterations ; ii++)
            {
                result = _source.FindIndex(SByte.MaxValue);
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public int SpanHelpers_IndexOf()
        {
            int result = -1;

            for (uint ii = 0 ; ii < _iterations ; ii++)
            {
                result = Array.IndexOf<SByte>(_source, SByte.MaxValue);
            }

            return result;
        }
    }
}
