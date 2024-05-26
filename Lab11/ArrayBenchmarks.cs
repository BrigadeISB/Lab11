using Benchmark;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using System;

[Config(typeof(BenchmarkConfig))]
public class ArrayBenchmarks
{
    [Params(1_000, 5_000, 25_000, 50_000, 100_000, 1_000_000)]
    public int N;

    [Params(ArrayType.Random, ArrayType.PartiallySorted, ArrayType.ManyDuplicates)]
    public ArrayType ArrayType;

    private int[] data;

    [GlobalSetup]
    public void Setup()
    {
        data = ArrayDataGenerator.GenerateArray(N, ArrayType);
    }

    [Benchmark(OperationsPerInvoke = 100)]
    public void HeapSort()
    {
        var tempArray = (int[])data.Clone();
        SortingAlgorithms.HeapSort(tempArray);
    }

    [Benchmark(OperationsPerInvoke = 100)]
    public void SmoothSort()
    {
        var tempArray = (int[])data.Clone();
        SortingAlgorithms.SmoothSort(tempArray);
    }

    [Benchmark(OperationsPerInvoke = 50)]
    public void QuickSort()
    {
        var tempArray = (int[])data.Clone();
        SortingAlgorithms.QuickSort(tempArray);
    }
}
