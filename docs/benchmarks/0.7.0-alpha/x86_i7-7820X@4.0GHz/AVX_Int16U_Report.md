``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7820X CPU 3.60GHz (Kaby Lake), 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.201
  [Host] : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  net3.1 : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT
  net5.0 : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT

RunStrategy=Throughput  

```
|              Method |    Job |       Runtime |    N |       Mean |   Error |   StdDev |  StdErr |        Min |         Q1 |     Median |         Q3 |        Max |   Op/s | Ratio | RatioSD |
|-------------------- |------- |-------------- |----- |-----------:|--------:|---------:|--------:|-----------:|-----------:|-----------:|-----------:|-----------:|-------:|------:|--------:|
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **128** |   **125.9 ms** | **1.74 ms** |  **1.46 ms** | **0.40 ms** |   **123.1 ms** |   **125.1 ms** |   **126.2 ms** |   **126.9 ms** |   **127.6 ms** | **7.9425** |  **0.78** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  128 |   161.4 ms | 0.08 ms |  0.07 ms | 0.02 ms |   161.2 ms |   161.3 ms |   161.3 ms |   161.4 ms |   161.5 ms | 6.1970 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  128 |   162.6 ms | 0.64 ms |  0.60 ms | 0.15 ms |   161.3 ms |   162.2 ms |   162.7 ms |   162.9 ms |   163.6 ms | 6.1516 |  0.92 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  128 |   177.6 ms | 0.98 ms |  0.92 ms | 0.24 ms |   176.1 ms |   176.9 ms |   177.5 ms |   178.1 ms |   179.8 ms | 5.6316 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **256** |   **272.2 ms** | **0.70 ms** |  **0.58 ms** | **0.16 ms** |   **270.8 ms** |   **271.8 ms** |   **272.3 ms** |   **272.5 ms** |   **273.1 ms** | **3.6742** |  **1.32** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  256 |   206.7 ms | 0.92 ms |  0.86 ms | 0.22 ms |   205.1 ms |   206.0 ms |   206.4 ms |   207.4 ms |   207.8 ms | 4.8382 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  256 |   263.9 ms | 0.77 ms |  0.60 ms | 0.17 ms |   263.4 ms |   263.6 ms |   263.7 ms |   263.9 ms |   265.3 ms | 3.7889 |  1.07 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  256 |   245.6 ms | 0.56 ms |  0.52 ms | 0.14 ms |   244.8 ms |   245.3 ms |   245.5 ms |   246.0 ms |   246.6 ms | 4.0710 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **512** |   **510.3 ms** | **9.47 ms** |  **9.30 ms** | **2.32 ms** |   **495.9 ms** |   **506.4 ms** |   **510.7 ms** |   **517.1 ms** |   **529.8 ms** | **1.9597** |  **1.20** |    **0.09** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  512 |   431.1 ms | 8.57 ms | 16.72 ms | 2.44 ms |   325.8 ms |   429.2 ms |   431.9 ms |   435.8 ms |   449.0 ms | 2.3196 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  512 |   490.9 ms | 3.73 ms |  3.30 ms | 0.88 ms |   488.3 ms |   488.9 ms |   489.2 ms |   492.3 ms |   499.1 ms | 2.0370 |  1.37 |    0.01 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  512 |   359.7 ms | 2.27 ms |  1.77 ms | 0.51 ms |   355.2 ms |   358.9 ms |   360.2 ms |   360.8 ms |   361.5 ms | 2.7803 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **1024** |   **949.2 ms** | **2.88 ms** |  **2.40 ms** | **0.67 ms** |   **946.8 ms** |   **947.9 ms** |   **948.3 ms** |   **949.3 ms** |   **955.5 ms** | **1.0535** |  **1.74** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 1024 |   544.6 ms | 2.53 ms |  2.24 ms | 0.60 ms |   542.1 ms |   542.9 ms |   544.1 ms |   545.6 ms |   550.2 ms | 1.8361 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 1024 |   947.1 ms | 0.86 ms |  0.67 ms | 0.19 ms |   946.2 ms |   946.9 ms |   947.1 ms |   947.3 ms |   948.8 ms | 1.0558 |  1.62 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 1024 |   583.0 ms | 1.96 ms |  1.64 ms | 0.45 ms |   580.6 ms |   582.0 ms |   582.7 ms |   583.5 ms |   587.1 ms | 1.7153 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **2048** | **1,986.6 ms** | **0.57 ms** |  **0.53 ms** | **0.14 ms** | **1,985.6 ms** | **1,986.3 ms** | **1,986.4 ms** | **1,987.1 ms** | **1,987.4 ms** | **0.5034** |  **1.82** |    **0.00** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 2048 | 1,089.1 ms | 1.26 ms |  1.12 ms | 0.30 ms | 1,086.4 ms | 1,088.6 ms | 1,089.2 ms | 1,089.7 ms | 1,091.0 ms | 0.9182 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 2048 | 1,963.5 ms | 0.82 ms |  0.73 ms | 0.19 ms | 1,962.7 ms | 1,962.9 ms | 1,963.4 ms | 1,963.9 ms | 1,965.3 ms | 0.5093 |  1.80 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 2048 | 1,089.8 ms | 0.60 ms |  0.56 ms | 0.14 ms | 1,088.8 ms | 1,089.5 ms | 1,089.8 ms | 1,090.1 ms | 1,090.9 ms | 0.9176 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **4096** | **3,757.7 ms** | **1.54 ms** |  **1.37 ms** | **0.37 ms** | **3,756.1 ms** | **3,756.7 ms** | **3,757.5 ms** | **3,758.2 ms** | **3,760.6 ms** | **0.2661** |  **1.92** |    **0.00** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 4096 | 1,961.0 ms | 0.76 ms |  0.71 ms | 0.18 ms | 1,959.8 ms | 1,960.4 ms | 1,961.0 ms | 1,961.5 ms | 1,962.3 ms | 0.5099 |  1.00 |    0.00 |
|                     |        |               |      |            |         |          |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 4096 | 3,788.2 ms | 1.55 ms |  1.45 ms | 0.37 ms | 3,786.2 ms | 3,787.2 ms | 3,788.0 ms | 3,788.9 ms | 3,791.1 ms | 0.2640 |  1.88 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 4096 | 2,011.4 ms | 3.04 ms |  2.85 ms | 0.74 ms | 2,008.1 ms | 2,008.8 ms | 2,010.6 ms | 2,013.9 ms | 2,015.9 ms | 0.4972 |  1.00 |    0.00 |
