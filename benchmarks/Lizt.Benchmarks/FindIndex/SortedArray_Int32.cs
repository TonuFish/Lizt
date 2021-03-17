using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Attributes;
using System;
using Lizt.Extensions;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Configs;
using System.Linq;

namespace Lizt.Benchmarks.FindIndex
{
    // dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'SortedArray_Int32'

    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp50, id: "net5.0")]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31, id: "net3.1")]
    [AsciiDocExporter, CsvExporter, HtmlExporter, JsonExporter(indentJson: true), MarkdownExporter, XmlExporter(indentXml: true)]
    [RPlotExporter, CsvMeasurementsExporter] // For R graphs
    [AllStatisticsColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class SortedArray_Int32
    {
        private int _iterations = 15_000_000;
        private int[] _source;

        //[Params(256, 512, 1_024, 2_048, 4_096, 8_192)]
        [Params(128)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var range = Enumerable.Range(int.MinValue, N - 1).Append(int.MaxValue);
            _source = range.ToArray();
        }

        //[Benchmark]
        //public int InfraOverhead()
        //{
        //    int result = -1;

        //    for (int ii = 0 ; ii < _iterations ; ii++)
        //    { }

        //    return result;
        //}

        [Benchmark(Baseline = true)]
        public int Lizt_Extensions()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = _source.FindIndex(int.MaxValue);
            }

            return result;
        }

        [Benchmark]
        public int SpanHelpers_IndexOf()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = Array.IndexOf<int>(_source, int.MaxValue);
            }

            return result;
        }

        // TODO: Write and test an unrolled loop

        [Benchmark]
        public int SpanHelpers_BinarySearch()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = Array.BinarySearch<int>(_source, int.MaxValue);
            }

            return result;
        }
    }
}
