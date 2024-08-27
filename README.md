```
BenchmarkDotNet v0.14.0, Windows 10
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2


| Method                  | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------ |------------:|----------:|----------:|------:|--------:|--------:|-------:|----------:|------------:|
| InterpolationToString   |    717.5 ns |   4.94 ns |   4.38 ns |  1.00 |    0.01 |  0.9842 |      - |   4.02 KB |        1.00 |
| OxpeckerToString        |  1,974.2 ns |   9.62 ns |   8.53 ns |  2.75 |    0.02 |  1.2207 |      - |   4.99 KB |        1.24 |
| GiraffeToString         |  2,708.0 ns |  37.33 ns |  34.92 ns |  3.77 |    0.05 |  3.7994 | 0.0038 |  15.55 KB |        3.86 |
| FalcoToString           |  2,456.4 ns |  25.42 ns |  22.54 ns |  3.42 |    0.04 |  1.8234 |      - |   7.46 KB |        1.85 |
| ScribanToString         | 18,297.9 ns | 217.45 ns | 192.76 ns | 25.50 |    0.30 |  9.7656 |      - |  40.21 KB |        9.99 |
| DotLiquidToString       | 50,641.8 ns | 307.76 ns | 287.88 ns | 70.58 |    0.57 | 10.0098 |      - |  41.81 KB |       10.39 |
| FluidToString           |  2,700.6 ns |  19.45 ns |  18.19 ns |  3.76 |    0.03 |  0.9651 |      - |   3.95 KB |        0.98 |
| RazorToString           |  9,684.0 ns | 110.83 ns |  86.53 ns | 13.50 |    0.14 |  1.2817 | 0.4272 |   7.91 KB |        1.97 |
| T4ToString              | 27,597.8 ns | 188.78 ns | 176.58 ns | 38.47 |    0.33 |  1.6479 |      - |   6.82 KB |        1.70 |
| HandlebarsToString      |  1,710.4 ns |  17.23 ns |  15.28 ns |  2.38 |    0.03 |  0.4501 |      - |   1.84 KB |        0.46 |
| OxpeckerTweakedToString |    783.3 ns |   5.84 ns |   4.88 ns |  1.09 |    0.01 |  0.6590 |      - |    2.7 KB |        0.67 |
```