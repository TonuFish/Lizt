``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7820X CPU 3.60GHz (Kaby Lake), 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.201
  [Host] : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  net3.1 : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT
  net5.0 : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT

RunStrategy=Throughput  

```
|              Method |    Job |       Runtime |    N |        Mean |     Error |    StdDev |   StdErr |         Min |          Q1 |      Median |          Q3 |         Max |    Op/s | Ratio | RatioSD |
|-------------------- |------- |-------------- |----- |------------:|----------:|----------:|---------:|------------:|------------:|------------:|------------:|------------:|--------:|------:|--------:|
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **128** |    **91.47 ms** |  **0.560 ms** |  **0.496 ms** | **0.133 ms** |    **90.79 ms** |    **91.08 ms** |    **91.39 ms** |    **91.72 ms** |    **92.54 ms** | **10.9328** |  **0.47** |    **0.00** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  128 |   193.32 ms |  1.244 ms |  1.164 ms | 0.301 ms |   191.07 ms |   192.45 ms |   193.53 ms |   194.22 ms |   195.39 ms |  5.1727 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  128 |    85.99 ms |  0.442 ms |  0.413 ms | 0.107 ms |    85.56 ms |    85.64 ms |    85.90 ms |    86.30 ms |    86.80 ms | 11.6290 |  0.77 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  128 |   111.97 ms |  0.393 ms |  0.368 ms | 0.095 ms |   111.28 ms |   111.83 ms |   111.93 ms |   112.16 ms |   112.59 ms |  8.9308 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **256** |   **122.45 ms** |  **0.734 ms** |  **0.687 ms** | **0.177 ms** |   **121.39 ms** |   **121.95 ms** |   **122.51 ms** |   **122.76 ms** |   **123.93 ms** |  **8.1668** |  **0.57** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  256 |   215.45 ms |  1.723 ms |  1.612 ms | 0.416 ms |   211.88 ms |   214.52 ms |   214.82 ms |   216.76 ms |   217.68 ms |  4.6415 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  256 |   116.57 ms |  0.296 ms |  0.277 ms | 0.071 ms |   116.29 ms |   116.37 ms |   116.41 ms |   116.73 ms |   117.13 ms |  8.5787 |  0.90 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  256 |   130.25 ms |  0.232 ms |  0.206 ms | 0.055 ms |   130.00 ms |   130.13 ms |   130.18 ms |   130.40 ms |   130.62 ms |  7.6774 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **512** |   **217.68 ms** |  **0.429 ms** |  **0.380 ms** | **0.102 ms** |   **217.06 ms** |   **217.43 ms** |   **217.59 ms** |   **217.83 ms** |   **218.52 ms** |  **4.5938** |  **0.80** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  512 |   272.20 ms |  3.147 ms |  2.944 ms | 0.760 ms |   265.36 ms |   270.64 ms |   271.78 ms |   274.06 ms |   276.98 ms |  3.6737 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  512 |   180.98 ms |  0.428 ms |  0.358 ms | 0.099 ms |   180.36 ms |   180.90 ms |   181.06 ms |   181.23 ms |   181.53 ms |  5.5254 |  1.03 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  512 |   176.31 ms |  0.385 ms |  0.360 ms | 0.093 ms |   175.88 ms |   175.98 ms |   176.19 ms |   176.58 ms |   176.93 ms |  5.6719 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **1024** |   **384.48 ms** |  **0.511 ms** |  **0.399 ms** | **0.115 ms** |   **383.68 ms** |   **384.25 ms** |   **384.55 ms** |   **384.82 ms** |   **384.90 ms** |  **2.6009** |  **1.33** |    **0.04** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 1024 |   284.90 ms |  5.577 ms |  9.005 ms | 1.544 ms |   269.88 ms |   277.67 ms |   284.82 ms |   289.32 ms |   305.75 ms |  3.5100 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 1024 |   299.04 ms |  0.427 ms |  0.356 ms | 0.099 ms |   298.42 ms |   298.82 ms |   299.01 ms |   299.28 ms |   299.62 ms |  3.3440 |  0.98 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 1024 |   303.72 ms |  1.098 ms |  0.974 ms | 0.260 ms |   302.53 ms |   303.00 ms |   303.38 ms |   304.18 ms |   305.61 ms |  3.2926 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **2048** |   **726.31 ms** |  **2.641 ms** |  **2.470 ms** | **0.638 ms** |   **723.06 ms** |   **724.66 ms** |   **725.61 ms** |   **727.65 ms** |   **731.13 ms** |  **1.3768** |  **1.51** |    **0.04** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 2048 |   477.05 ms |  9.309 ms | 14.764 ms | 2.570 ms |   448.28 ms |   465.71 ms |   476.08 ms |   488.10 ms |   503.95 ms |  2.0962 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 2048 |   536.74 ms |  6.531 ms |  5.790 ms | 1.547 ms |   531.21 ms |   533.08 ms |   534.48 ms |   538.57 ms |   550.54 ms |  1.8631 |  1.14 |    0.01 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 2048 |   472.12 ms |  0.941 ms |  0.834 ms | 0.223 ms |   471.16 ms |   471.40 ms |   471.95 ms |   472.64 ms |   473.82 ms |  2.1181 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **4096** | **1,511.03 ms** |  **1.718 ms** |  **1.523 ms** | **0.407 ms** | **1,507.98 ms** | **1,510.27 ms** | **1,511.18 ms** | **1,511.98 ms** | **1,514.38 ms** |  **0.6618** |  **1.39** |    **0.02** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 4096 | 1,082.71 ms | 18.378 ms | 17.190 ms | 4.439 ms | 1,058.92 ms | 1,068.56 ms | 1,085.71 ms | 1,092.35 ms | 1,118.09 ms |  0.9236 |  1.00 |    0.00 |
|                     |        |               |      |             |           |           |          |             |             |             |             |             |         |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 4096 | 1,156.97 ms | 14.540 ms | 13.600 ms | 3.512 ms | 1,120.33 ms | 1,153.78 ms | 1,161.68 ms | 1,163.89 ms | 1,174.19 ms |  0.8643 |  1.26 |    0.01 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 4096 |   921.32 ms |  3.172 ms |  2.967 ms | 0.766 ms |   916.37 ms |   919.62 ms |   921.01 ms |   923.16 ms |   926.95 ms |  1.0854 |  1.00 |    0.00 |
