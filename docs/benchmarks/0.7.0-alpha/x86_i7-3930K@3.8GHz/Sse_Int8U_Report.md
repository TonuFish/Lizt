``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-3930K CPU 3.20GHz (Ivy Bridge), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.201
  [Host] : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  net3.1 : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT
  net5.0 : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT

RunStrategy=Throughput  

```
|              Method |    Job |       Runtime |    N |       Mean |    Error |   StdDev |  StdErr |        Min |         Q1 |     Median |         Q3 |        Max |   Op/s | Ratio |
|-------------------- |------- |-------------- |----- |-----------:|---------:|---------:|--------:|-----------:|-----------:|-----------:|-----------:|-----------:|-------:|------:|
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **128** |   **182.3 ms** |  **0.27 ms** |  **0.23 ms** | **0.06 ms** |   **182.0 ms** |   **182.1 ms** |   **182.2 ms** |   **182.4 ms** |   **182.7 ms** | **5.4863** |  **0.81** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  128 |   225.6 ms |  0.13 ms |  0.12 ms | 0.03 ms |   225.4 ms |   225.5 ms |   225.5 ms |   225.6 ms |   225.8 ms | 4.4335 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  128 |   170.2 ms |  0.21 ms |  0.18 ms | 0.05 ms |   169.9 ms |   170.0 ms |   170.1 ms |   170.4 ms |   170.5 ms | 5.8758 |  0.66 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  128 |   257.9 ms |  0.76 ms |  0.71 ms | 0.18 ms |   257.0 ms |   257.3 ms |   257.7 ms |   258.4 ms |   259.2 ms | 3.8774 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **256** |   **276.9 ms** |  **0.15 ms** |  **0.12 ms** | **0.03 ms** |   **276.8 ms** |   **276.8 ms** |   **276.8 ms** |   **276.9 ms** |   **277.2 ms** | **3.6117** |  **0.86** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  256 |   320.3 ms |  0.08 ms |  0.07 ms | 0.02 ms |   320.1 ms |   320.2 ms |   320.3 ms |   320.3 ms |   320.4 ms | 3.1224 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  256 |   263.7 ms |  0.46 ms |  0.38 ms | 0.11 ms |   263.1 ms |   263.5 ms |   263.7 ms |   264.0 ms |   264.5 ms | 3.7917 |  0.75 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  256 |   352.2 ms |  0.39 ms |  0.33 ms | 0.09 ms |   351.9 ms |   352.0 ms |   352.1 ms |   352.1 ms |   352.9 ms | 2.8395 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** |  **512** |   **467.2 ms** |  **0.82 ms** |  **0.73 ms** | **0.19 ms** |   **466.5 ms** |   **466.7 ms** |   **466.8 ms** |   **467.5 ms** |   **469.1 ms** | **2.1406** |  **0.91** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 |  512 |   514.2 ms |  0.12 ms |  0.11 ms | 0.03 ms |   514.0 ms |   514.1 ms |   514.2 ms |   514.2 ms |   514.4 ms | 1.9449 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 |  512 |   454.7 ms |  0.11 ms |  0.10 ms | 0.03 ms |   454.6 ms |   454.6 ms |   454.7 ms |   454.8 ms |   454.9 ms | 2.1992 |  0.83 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 |  512 |   549.2 ms |  0.70 ms |  0.59 ms | 0.16 ms |   547.7 ms |   548.8 ms |   549.3 ms |   549.6 ms |   549.8 ms | 1.8209 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **1024** |   **908.3 ms** |  **0.44 ms** |  **0.39 ms** | **0.10 ms** |   **907.8 ms** |   **908.1 ms** |   **908.2 ms** |   **908.5 ms** |   **909.2 ms** | **1.1009** |  **1.05** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 1024 |   861.9 ms |  0.16 ms |  0.15 ms | 0.04 ms |   861.7 ms |   861.8 ms |   861.9 ms |   862.0 ms |   862.2 ms | 1.1602 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 1024 |   911.8 ms |  0.32 ms |  0.30 ms | 0.08 ms |   911.4 ms |   911.6 ms |   911.7 ms |   912.0 ms |   912.3 ms | 1.0967 |  1.03 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 1024 |   885.1 ms |  0.72 ms |  0.67 ms | 0.17 ms |   883.2 ms |   885.1 ms |   885.4 ms |   885.6 ms |   885.7 ms | 1.1298 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **2048** | **1,547.0 ms** |  **0.43 ms** |  **0.38 ms** | **0.10 ms** | **1,546.5 ms** | **1,546.7 ms** | **1,546.9 ms** | **1,547.2 ms** | **1,547.7 ms** | **0.6464** |  **1.15** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 2048 | 1,348.0 ms |  0.28 ms |  0.25 ms | 0.07 ms | 1,347.6 ms | 1,347.8 ms | 1,347.9 ms | 1,348.1 ms | 1,348.5 ms | 0.7418 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 2048 | 1,603.8 ms |  0.38 ms |  0.32 ms | 0.09 ms | 1,603.3 ms | 1,603.6 ms | 1,603.8 ms | 1,604.0 ms | 1,604.4 ms | 0.6235 |  1.15 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 2048 | 1,390.9 ms |  0.63 ms |  0.58 ms | 0.15 ms | 1,389.3 ms | 1,390.8 ms | 1,391.0 ms | 1,391.2 ms | 1,391.6 ms | 0.7189 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      **Lizt_FindIndex** | **net3.1** | **.NET Core 3.1** | **4096** | **2,829.3 ms** | **18.35 ms** | **16.27 ms** | **4.35 ms** | **2,816.7 ms** | **2,818.7 ms** | **2,821.0 ms** | **2,834.6 ms** | **2,869.5 ms** | **0.3534** |  **1.19** |
| SpanHelpers_IndexOf | net3.1 | .NET Core 3.1 | 4096 | 2,379.6 ms |  0.69 ms |  0.61 ms | 0.16 ms | 2,379.0 ms | 2,379.3 ms | 2,379.4 ms | 2,379.9 ms | 2,381.1 ms | 0.4202 |  1.00 |
|                     |        |               |      |            |          |          |         |            |            |            |            |            |        |       |
|      Lizt_FindIndex | net5.0 | .NET Core 5.0 | 4096 | 2,813.1 ms |  0.86 ms |  0.72 ms | 0.20 ms | 2,811.6 ms | 2,812.7 ms | 2,813.2 ms | 2,813.3 ms | 2,814.2 ms | 0.3555 |  1.17 |
| SpanHelpers_IndexOf | net5.0 | .NET Core 5.0 | 4096 | 2,410.4 ms |  0.43 ms |  0.38 ms | 0.10 ms | 2,409.7 ms | 2,410.2 ms | 2,410.3 ms | 2,410.6 ms | 2,411.2 ms | 0.4149 |  1.00 |
