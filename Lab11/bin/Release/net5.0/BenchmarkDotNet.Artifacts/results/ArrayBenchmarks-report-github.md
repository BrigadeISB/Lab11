```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
12th Gen Intel Core i5-12450H, 1 CPU, 12 logical and 8 physical cores
.NET SDK 9.0.100-preview.3.24204.13
  [Host]     : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2
  Job-CMFRRR : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2

IterationCount=10  RunStrategy=Throughput  WarmupCount=5  

```
| Method     | N    | ArrayType       | Mean       | Error    | StdDev   | Gen0   | Allocated |
|----------- |----- |---------------- |-----------:|---------:|---------:|-------:|----------:|
| **HeapSort**   | **1000** | **Random**          |   **274.2 ns** |  **6.15 ns** |  **4.07 ns** | **0.0061** |      **40 B** |
| SmoothSort | 1000 | Random          |   688.5 ns | 12.45 ns |  8.24 ns | 0.0061 |      40 B |
| QuickSort  | 1000 | Random          |   275.6 ns |  2.72 ns |  1.80 ns | 0.0125 |      80 B |
| **HeapSort**   | **1000** | **PartiallySorted** |   **275.0 ns** |  **0.72 ns** |  **0.43 ns** | **0.0061** |      **40 B** |
| SmoothSort | 1000 | PartiallySorted |   601.7 ns | 17.28 ns | 10.28 ns | 0.0061 |      40 B |
| QuickSort  | 1000 | PartiallySorted |   239.5 ns |  2.27 ns |  1.50 ns | 0.0125 |      80 B |
| **HeapSort**   | **1000** | **ManyDuplicates**  |   **269.8 ns** |  **3.89 ns** |  **2.57 ns** | **0.0061** |      **40 B** |
| SmoothSort | 1000 | ManyDuplicates  |   684.4 ns |  4.93 ns |  3.26 ns | 0.0061 |      40 B |
| QuickSort  | 1000 | ManyDuplicates  |   227.8 ns |  1.04 ns |  0.69 ns | 0.0125 |      80 B |
| **HeapSort**   | **2500** | **Random**          | **1,212.1 ns** |  **1.40 ns** |  **0.73 ns** | **0.0159** |     **100 B** |
| SmoothSort | 2500 | Random          | 2,428.5 ns | 13.52 ns |  8.04 ns | 0.0146 |     100 B |
| QuickSort  | 2500 | Random          | 1,590.7 ns | 13.89 ns |  9.18 ns | 0.0317 |     200 B |
| **HeapSort**   | **2500** | **PartiallySorted** | **1,118.7 ns** |  **2.36 ns** |  **1.56 ns** | **0.0159** |     **100 B** |
| SmoothSort | 2500 | PartiallySorted | 2,219.1 ns | 31.69 ns | 18.86 ns | 0.0146 |     100 B |
| QuickSort  | 2500 | PartiallySorted | 1,218.4 ns |  6.98 ns |  4.62 ns | 0.0317 |     200 B |
| **HeapSort**   | **2500** | **ManyDuplicates**  | **1,225.6 ns** |  **5.11 ns** |  **3.04 ns** | **0.0146** |     **100 B** |
| SmoothSort | 2500 | ManyDuplicates  | 2,533.5 ns | 79.66 ns | 52.69 ns | 0.0146 |     100 B |
| QuickSort  | 2500 | ManyDuplicates  | 1,358.3 ns | 19.01 ns |  9.94 ns | 0.0317 |     200 B |
| **HeapSort**   | **5000** | **Random**          | **2,963.5 ns** | **24.16 ns** | **15.98 ns** | **0.0293** |     **200 B** |
| SmoothSort | 5000 | Random          | 5,528.3 ns | 39.86 ns | 23.72 ns | 0.0293 |     200 B |
| QuickSort  | 5000 | Random          | 3,857.5 ns | 25.19 ns | 14.99 ns | 0.0635 |     401 B |
| **HeapSort**   | **5000** | **PartiallySorted** | **2,653.8 ns** | **10.13 ns** |  **6.70 ns** | **0.0293** |     **200 B** |
| SmoothSort | 5000 | PartiallySorted | 4,982.5 ns | 55.30 ns | 36.58 ns | 0.0293 |     200 B |
| QuickSort  | 5000 | PartiallySorted | 3,367.0 ns | 11.85 ns |  7.84 ns | 0.0635 |     401 B |
| **HeapSort**   | **5000** | **ManyDuplicates**  | **2,932.2 ns** |  **8.80 ns** |  **5.24 ns** | **0.0293** |     **200 B** |
| SmoothSort | 5000 | ManyDuplicates  | 5,568.5 ns | 29.68 ns | 15.53 ns | 0.0293 |     200 B |
| QuickSort  | 5000 | ManyDuplicates  | 3,273.1 ns |  9.78 ns |  6.47 ns | 0.0635 |     401 B |
