``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-3930K CPU 3.20GHz (Ivy Bridge), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.201
  [Host] : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  net3.1 : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT
  net5.0 : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT

RunStrategy=Throughput  

```
|              Method |    Job |       Runtime |    N |       Mean |   Error |  StdDev |  StdErr |        Min |         Q1 |     Median |         Q3 |        Max |   Op/s | Ratio |
|-------------------- |------- |-------------- |----- |-----------:|--------:|--------:|--------:|-----------:|-----------:|-----------:|-----------:|-----------:|-------:|------:|
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **128** |   **304.7 ms** | **0.10 ms** | **0.18 ms** | **0.03 ms** |   **304.5 ms** |   **304.6 ms** |   **304.6 ms** |   **304.7 ms** |   **305.3 ms** | **3.2821** |  **0.98** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  128 |   312.4 ms | 0.08 ms | 0.07 ms | 0.02 ms |   312.3 ms |   312.3 ms |   312.4 ms |   312.4 ms |   312.5 ms | 3.2012 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  128 |   268.9 ms | 0.17 ms | 0.14 ms | 0.04 ms |   268.7 ms |   268.8 ms |   268.9 ms |   269.0 ms |   269.2 ms | 3.7184 |  0.79 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  128 |   340.8 ms | 0.30 ms | 0.28 ms | 0.07 ms |   340.2 ms |   340.6 ms |   340.8 ms |   341.0 ms |   341.2 ms | 2.9345 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **256** |   **471.6 ms** | **1.16 ms** | **1.09 ms** | **0.28 ms** |   **470.5 ms** |   **470.7 ms** |   **470.8 ms** |   **472.8 ms** |   **473.2 ms** | **2.1202** |  **0.95** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  256 |   494.4 ms | 0.19 ms | 0.16 ms | 0.04 ms |   494.2 ms |   494.3 ms |   494.3 ms |   494.4 ms |   494.8 ms | 2.0228 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  256 |   458.8 ms | 0.20 ms | 0.16 ms | 0.05 ms |   458.5 ms |   458.7 ms |   458.8 ms |   458.9 ms |   459.0 ms | 2.1797 |  0.86 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  256 |   530.9 ms | 0.39 ms | 0.36 ms | 0.09 ms |   530.2 ms |   530.6 ms |   530.9 ms |   531.2 ms |   531.5 ms | 1.8837 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **512** |   **850.9 ms** | **0.37 ms** | **0.29 ms** | **0.08 ms** |   **850.5 ms** |   **850.7 ms** |   **850.8 ms** |   **851.0 ms** |   **851.4 ms** | **1.1753** |  **0.93** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  512 |   917.8 ms | 2.92 ms | 2.73 ms | 0.71 ms |   912.6 ms |   916.6 ms |   917.5 ms |   920.0 ms |   921.3 ms | 1.0896 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  512 |   920.5 ms | 0.40 ms | 0.35 ms | 0.09 ms |   919.9 ms |   920.2 ms |   920.6 ms |   920.8 ms |   921.0 ms | 1.0863 |  1.01 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  512 |   907.4 ms | 1.37 ms | 1.29 ms | 0.33 ms |   904.7 ms |   906.6 ms |   907.8 ms |   908.1 ms |   910.1 ms | 1.1020 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **1024** | **1,387.2 ms** | **1.18 ms** | **1.11 ms** | **0.29 ms** | **1,385.1 ms** | **1,386.5 ms** | **1,387.3 ms** | **1,388.2 ms** | **1,388.8 ms** | **0.7209** |  **0.84** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 1024 | 1,646.4 ms | 0.21 ms | 0.18 ms | 0.05 ms | 1,646.1 ms | 1,646.2 ms | 1,646.4 ms | 1,646.5 ms | 1,646.6 ms | 0.6074 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 1024 | 1,590.4 ms | 0.31 ms | 0.28 ms | 0.07 ms | 1,590.0 ms | 1,590.2 ms | 1,590.4 ms | 1,590.7 ms | 1,590.8 ms | 0.6288 |  1.06 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 1024 | 1,503.1 ms | 2.38 ms | 2.22 ms | 0.57 ms | 1,498.9 ms | 1,501.7 ms | 1,503.8 ms | 1,504.8 ms | 1,506.0 ms | 0.6653 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **2048** | **2,408.2 ms** | **1.52 ms** | **1.43 ms** | **0.37 ms** | **2,405.9 ms** | **2,407.0 ms** | **2,408.4 ms** | **2,409.4 ms** | **2,410.4 ms** | **0.4152** |  **0.84** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 2048 | 2,872.3 ms | 0.80 ms | 0.74 ms | 0.19 ms | 2,870.7 ms | 2,871.9 ms | 2,872.1 ms | 2,872.8 ms | 2,873.6 ms | 0.3482 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 2048 | 2,839.4 ms | 2.83 ms | 2.65 ms | 0.68 ms | 2,836.0 ms | 2,837.3 ms | 2,838.4 ms | 2,841.1 ms | 2,844.9 ms | 0.3522 |  1.07 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 2048 | 2,647.1 ms | 0.58 ms | 0.54 ms | 0.14 ms | 2,646.1 ms | 2,646.8 ms | 2,647.2 ms | 2,647.4 ms | 2,648.0 ms | 0.3778 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **4096** | **4,433.0 ms** | **1.04 ms** | **0.92 ms** | **0.25 ms** | **4,431.6 ms** | **4,432.3 ms** | **4,432.9 ms** | **4,433.8 ms** | **4,434.5 ms** | **0.2256** |  **0.79** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 4096 | 5,617.2 ms | 1.22 ms | 1.02 ms | 0.28 ms | 5,615.7 ms | 5,616.4 ms | 5,617.0 ms | 5,617.8 ms | 5,619.3 ms | 0.1780 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 4096 | 5,487.7 ms | 1.09 ms | 0.91 ms | 0.25 ms | 5,485.8 ms | 5,487.4 ms | 5,487.6 ms | 5,487.8 ms | 5,489.5 ms | 0.1822 |  1.11 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 4096 | 4,943.0 ms | 1.11 ms | 1.03 ms | 0.27 ms | 4,941.0 ms | 4,942.4 ms | 4,943.2 ms | 4,944.0 ms | 4,944.4 ms | 0.2023 |  1.00 |
