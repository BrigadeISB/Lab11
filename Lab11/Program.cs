﻿using System;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ArrayBenchmarks>();
        }
    }
}