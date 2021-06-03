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
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **128** |   **180.8 ms** | **0.59 ms** | **0.56 ms** | **0.14 ms** |   **180.2 ms** |   **180.2 ms** |   **180.9 ms** |   **181.1 ms** |   **181.9 ms** | **5.5314** |  **0.79** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  128 |   228.1 ms | 0.98 ms | 0.92 ms | 0.24 ms |   226.7 ms |   227.4 ms |   228.0 ms |   228.6 ms |   230.0 ms | 4.3842 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  128 |   171.3 ms | 0.67 ms | 0.62 ms | 0.16 ms |   170.6 ms |   170.8 ms |   171.1 ms |   171.7 ms |   172.7 ms | 5.8367 |  0.66 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  128 |   260.0 ms | 1.08 ms | 0.84 ms | 0.24 ms |   258.5 ms |   259.5 ms |   259.9 ms |   260.5 ms |   261.4 ms | 3.8456 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **256** |   **300.2 ms** | **2.75 ms** | **2.14 ms** | **0.62 ms** |   **298.5 ms** |   **299.2 ms** |   **299.9 ms** |   **300.2 ms** |   **306.7 ms** | **3.3311** |  **0.93** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  256 |   323.6 ms | 0.92 ms | 0.86 ms | 0.22 ms |   322.4 ms |   323.0 ms |   323.2 ms |   324.4 ms |   324.8 ms | 3.0902 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  256 |   272.5 ms | 2.19 ms | 1.83 ms | 0.51 ms |   269.9 ms |   271.2 ms |   272.5 ms |   273.2 ms |   276.4 ms | 3.6702 |  0.75 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  256 |   364.2 ms | 1.95 ms | 1.82 ms | 0.47 ms |   361.2 ms |   362.7 ms |   364.8 ms |   365.6 ms |   367.0 ms | 2.7455 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **512** |   **462.8 ms** | **0.22 ms** | **0.18 ms** | **0.05 ms** |   **462.6 ms** |   **462.7 ms** |   **462.7 ms** |   **462.8 ms** |   **463.2 ms** | **2.1608** |  **0.90** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  512 |   514.1 ms | 0.12 ms | 0.10 ms | 0.03 ms |   513.9 ms |   514.0 ms |   514.1 ms |   514.1 ms |   514.3 ms | 1.9452 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  512 |   459.9 ms | 0.50 ms | 0.47 ms | 0.12 ms |   459.2 ms |   459.7 ms |   459.9 ms |   460.2 ms |   460.8 ms | 2.1742 |  0.83 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  512 |   551.5 ms | 6.31 ms | 7.51 ms | 1.64 ms |   548.7 ms |   549.1 ms |   549.5 ms |   549.7 ms |   582.5 ms | 1.8132 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **1024** |   **875.9 ms** | **0.48 ms** | **0.42 ms** | **0.11 ms** |   **874.8 ms** |   **875.8 ms** |   **875.8 ms** |   **876.1 ms** |   **876.5 ms** | **1.1417** |  **1.02** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 1024 |   861.7 ms | 0.13 ms | 0.11 ms | 0.03 ms |   861.5 ms |   861.6 ms |   861.7 ms |   861.8 ms |   861.9 ms | 1.1605 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 1024 | 1,000.5 ms | 0.90 ms | 0.84 ms | 0.22 ms |   998.8 ms | 1,000.1 ms | 1,000.5 ms | 1,001.0 ms | 1,001.6 ms | 0.9995 |  1.12 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 1024 |   893.1 ms | 0.46 ms | 0.43 ms | 0.11 ms |   892.0 ms |   893.0 ms |   893.2 ms |   893.4 ms |   893.5 ms | 1.1197 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **2048** | **1,449.1 ms** | **0.99 ms** | **0.93 ms** | **0.24 ms** | **1,447.6 ms** | **1,448.4 ms** | **1,449.2 ms** | **1,449.9 ms** | **1,450.5 ms** | **0.6901** |  **1.08** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 2048 | 1,347.9 ms | 0.31 ms | 0.28 ms | 0.07 ms | 1,347.6 ms | 1,347.7 ms | 1,347.8 ms | 1,348.0 ms | 1,348.5 ms | 0.7419 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 2048 | 1,744.4 ms | 1.45 ms | 1.36 ms | 0.35 ms | 1,741.6 ms | 1,743.6 ms | 1,744.2 ms | 1,745.0 ms | 1,747.0 ms | 0.5733 |  1.25 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 2048 | 1,390.9 ms | 0.49 ms | 0.46 ms | 0.12 ms | 1,390.2 ms | 1,390.7 ms | 1,391.0 ms | 1,391.2 ms | 1,391.7 ms | 0.7189 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **4096** | **2,526.5 ms** | **2.07 ms** | **1.93 ms** | **0.50 ms** | **2,523.0 ms** | **2,525.2 ms** | **2,527.3 ms** | **2,527.9 ms** | **2,528.6 ms** | **0.3958** |  **1.07** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 4096 | 2,359.4 ms | 0.25 ms | 0.23 ms | 0.06 ms | 2,359.1 ms | 2,359.2 ms | 2,359.3 ms | 2,359.5 ms | 2,359.9 ms | 0.4238 |  1.00 |
|                     |        |               |      |            |         |         |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 4096 | 3,125.6 ms | 1.92 ms | 1.80 ms | 0.46 ms | 3,122.0 ms | 3,124.9 ms | 3,125.7 ms | 3,126.6 ms | 3,128.4 ms | 0.3199 |  1.30 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 4096 | 2,410.2 ms | 0.43 ms | 0.40 ms | 0.10 ms | 2,409.1 ms | 2,410.0 ms | 2,410.3 ms | 2,410.4 ms | 2,410.7 ms | 0.4149 |  1.00 |
