using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddJob(Job.Default
                .WithWarmupCount(5)
                .WithIterationCount(10)
                .WithStrategy(RunStrategy.Throughput));
            AddExporter(RPlotExporter.Default);
            AddDiagnoser(MemoryDiagnoser.Default);
        }
    }
}
