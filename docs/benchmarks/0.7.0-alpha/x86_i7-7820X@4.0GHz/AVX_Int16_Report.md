``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7820X CPU 3.60GHz (Kaby Lake), 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.201
  [Host] : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  net3.1 : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT
  net5.0 : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT

RunStrategy=Throughput  

```
|              Method |    Job |       Runtime |    N |       Mean |   Error |  StdDev |  StdErr |        Min |         Q1 |     Median |         Q3 |        Max |   Op/s | Ratio | RatioSD |
|-------------------- |------- |-------------- |----- |-----------:|--------:|--------:|--------:|-----------:|-----------:|-----------:|-----------:|-----------:|-------:|------:|--------:|
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **128** |   **126.1 ms** | **1.31 ms** | **1.16 ms** | **0.31 ms** |   **124.3 ms** |   **125.5 ms** |   **125.6 ms** |   **126.8 ms** |   **128.2 ms** | **7.9279** |  **0.81** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  128 |   155.9 ms | 0.34 ms | 0.31 ms | 0.08 ms |   155.4 ms |   155.7 ms |   156.0 ms |   156.1 ms |   156.5 ms | 6.4138 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  128 |   136.8 ms | 0.12 ms | 0.10 ms | 0.03 ms |   136.6 ms |   136.8 ms |   136.8 ms |   136.9 ms |   136.9 ms | 7.3084 |  0.81 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  128 |   169.8 ms | 0.76 ms | 0.71 ms | 0.18 ms |   169.0 ms |   169.2 ms |   169.5 ms |   170.4 ms |   171.3 ms | 5.8899 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **256** |   **205.3 ms** | **0.87 ms** | **0.82 ms** | **0.21 ms** |   **203.8 ms** |   **204.8 ms** |   **205.0 ms** |   **206.0 ms** |   **206.7 ms** | **4.8719** |  **0.97** |    **0.00** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  256 |   212.4 ms | 0.43 ms | 0.38 ms | 0.10 ms |   211.9 ms |   212.1 ms |   212.3 ms |   212.5 ms |   213.3 ms | 4.7081 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  256 |   220.8 ms | 0.12 ms | 0.12 ms | 0.03 ms |   220.6 ms |   220.8 ms |   220.9 ms |   220.9 ms |   221.0 ms | 4.5280 |  0.94 |    0.01 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  256 |   235.3 ms | 2.50 ms | 2.21 ms | 0.59 ms |   231.5 ms |   234.3 ms |   234.9 ms |   236.8 ms |   239.9 ms | 4.2506 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **512** |   **310.8 ms** | **2.05 ms** | **1.82 ms** | **0.49 ms** |   **308.7 ms** |   **309.2 ms** |   **310.2 ms** |   **311.5 ms** |   **314.4 ms** | **3.2179** |  **0.91** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  512 |   342.3 ms | 4.11 ms | 3.21 ms | 0.93 ms |   338.1 ms |   340.6 ms |   341.2 ms |   344.9 ms |   349.4 ms | 2.9210 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  512 |   391.7 ms | 4.91 ms | 4.36 ms | 1.16 ms |   388.9 ms |   389.1 ms |   389.5 ms |   392.0 ms |   401.8 ms | 2.5528 |  1.14 |    0.02 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  512 |   344.2 ms | 2.71 ms | 2.40 ms | 0.64 ms |   340.3 ms |   342.9 ms |   344.3 ms |   345.1 ms |   348.9 ms | 2.9050 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **1024** |   **561.5 ms** | **9.39 ms** | **8.33 ms** | **2.23 ms** |   **556.1 ms** |   **556.9 ms** |   **557.4 ms** |   **560.8 ms** |   **580.6 ms** | **1.7809** |  **1.00** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 1024 |   559.3 ms | 1.39 ms | 1.30 ms | 0.34 ms |   556.9 ms |   558.2 ms |   559.3 ms |   560.3 ms |   561.1 ms | 1.7881 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 1024 |   548.0 ms | 0.65 ms | 0.54 ms | 0.15 ms |   547.2 ms |   547.5 ms |   547.8 ms |   548.3 ms |   549.0 ms | 1.8248 |  0.94 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 1024 |   583.8 ms | 1.68 ms | 1.57 ms | 0.41 ms |   581.7 ms |   582.2 ms |   583.7 ms |   585.2 ms |   586.3 ms | 1.7130 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **2048** | **1,511.5 ms** | **8.29 ms** | **7.75 ms** | **2.00 ms** | **1,501.4 ms** | **1,506.2 ms** | **1,508.2 ms** | **1,518.2 ms** | **1,526.1 ms** | **0.6616** |  **1.37** |    **0.01** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 2048 | 1,102.1 ms | 1.11 ms | 0.99 ms | 0.26 ms | 1,100.9 ms | 1,101.5 ms | 1,101.8 ms | 1,102.1 ms | 1,104.4 ms | 0.9074 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 2048 | 1,519.2 ms | 4.73 ms | 4.42 ms | 1.14 ms | 1,512.6 ms | 1,515.5 ms | 1,518.6 ms | 1,524.0 ms | 1,524.8 ms | 0.6582 |  1.39 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 2048 | 1,094.8 ms | 0.74 ms | 0.69 ms | 0.18 ms | 1,093.7 ms | 1,094.4 ms | 1,094.8 ms | 1,095.3 ms | 1,095.9 ms | 0.9134 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **4096** | **2,862.9 ms** | **1.36 ms** | **1.27 ms** | **0.33 ms** | **2,860.8 ms** | **2,862.0 ms** | **2,862.7 ms** | **2,863.6 ms** | **2,865.2 ms** | **0.3493** |  **1.46** |    **0.00** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 4096 | 1,961.8 ms | 1.41 ms | 1.32 ms | 0.34 ms | 1,959.9 ms | 1,961.0 ms | 1,961.5 ms | 1,962.9 ms | 1,964.1 ms | 0.5097 |  1.00 |    0.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |         |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 4096 | 2,117.5 ms | 3.11 ms | 2.91 ms | 0.75 ms | 2,111.7 ms | 2,115.4 ms | 2,117.3 ms | 2,119.3 ms | 2,122.7 ms | 0.4722 |  1.06 |    0.00 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 4096 | 2,001.9 ms | 0.72 ms | 0.64 ms | 0.17 ms | 2,001.1 ms | 2,001.4 ms | 2,002.0 ms | 2,002.3 ms | 2,003.0 ms | 0.4995 |  1.00 |    0.00 |
