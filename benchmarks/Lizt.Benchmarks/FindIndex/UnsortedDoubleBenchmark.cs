﻿using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Attributes;
using System;
using Lizt.Extensions;
using System.Collections.Generic;
using BenchmarkDotNet.Jobs;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Configs;

namespace Lizt.Benchmarks.FindIndex
{
    // dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'UnsortedDoubleBenchmark'

    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp50, id: "net5.0")]
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NetCoreApp31, id: "net3.1")]
    [AsciiDocExporter, CsvExporter, HtmlExporter, JsonExporter(indentJson: true), MarkdownExporter, XmlExporter(indentXml: true)]
    [RPlotExporter, CsvMeasurementsExporter] // For graphing
    [AllStatisticsColumn] // ProperRunWithROutput_1
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class UnsortedDoubleBenchmark
    {
        private int _iterations = 3_000_000;
        private double[] _source;
        private List<double> _sourceAsList;

        //[Params(64, 128, 256, 512, 1_024, 2_048, 4_096, 8_192, 16_384, 32_768, 65_536, 131_072, 262_144, 524_288, 1_048_576)]
        [Params(256, 512, 1_024, 2_048)]
        public int N;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool Match(double x) => x == double.MaxValue;

        // TODO: configure setup to take params{}, N and location of match?
        [GlobalSetup]
        public void Setup()
        {
            _source = new double[N];
            var rand = new Random(0);
            for (int ii = 0 ; ii < _source.Length ; ii++)
            {
                _source[ii] = rand.NextDouble();
            }
            _source[N - 1] = double.MaxValue;
            _sourceAsList = new List<double>(_source);
        }

        [Benchmark]
        public int InfraOverhead()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            { }

            return result;
        }

        [Benchmark(Baseline = true)]
        public int Lizt_Extensions()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = _source.FindIndex(double.MaxValue);
            }

            return result;
        }

        [Benchmark]
        public int System_For()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                for (int idx = 0 ; idx < _source.Length ; idx++)
                {
                    if (_source[idx] == double.MaxValue)
                    {
                        result = idx;
                        break;
                    }
                }
            }

            return result;
        }

        // TODO: Write and test an unrolled loop

        [Benchmark]
        public int System_Array()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = Array.FindIndex<double>(_source, Match);
            }

            return result;
        }

        [Benchmark]
        public int System_List()
        {
            int result = -1;

            for (int ii = 0 ; ii < _iterations ; ii++)
            {
                result = _sourceAsList.FindIndex(Match);
            }

            return result;
        }
    }
}