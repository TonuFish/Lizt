﻿using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Attributes;
using System;
using Lizt.Extensions;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Configs;

namespace Lizt.Benchmarks.FindIndex
{
    // dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_Int16'

    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp50, id: "net5.0")]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31, id: "net3.1")]
    [AsciiDocExporter, CsvExporter, HtmlExporter, JsonExporter(indentJson: true), MarkdownExporter, XmlExporter(indentXml: true)]
    [RPlotExporter, CsvMeasurementsExporter] // For R graphs
    [AllStatisticsColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class Array_Int16
    {
        private uint _iterations = 5_000_000;
        private Int16[] _source;

        [Params(128, 256, 512, 1_024, 2_048, 4_096)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _source = new Int16[N];
            var rand = new Random(765);
            for (int ii = 0 ; ii < _source.Length ; ii++)
            {
                _source[ii] = (Int16)rand.Next(0, Int16.MaxValue - 1);
            }
            _source[N - 1] = Int16.MaxValue;
        }

        [Benchmark]
        public int Lizt_FindIndex()
        {
            int result = -1;

            for (uint ii = 0 ; ii < _iterations ; ii++)
            {
                result = _source.FindIndex(Int16.MaxValue);
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public int SpanHelpers_IndexOf()
        {
            int result = -1;

            for (uint ii = 0 ; ii < _iterations ; ii++)
            {
                result = Array.IndexOf<Int16>(_source, Int16.MaxValue);
            }

            return result;
        }
    }
}
