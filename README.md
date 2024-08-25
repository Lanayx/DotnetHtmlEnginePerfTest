```
BenchmarkDotNet v0.14.0, Windows 10
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2



| Method                  | Mean        | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1   | Allocated | Alloc Ratio |
|------------------------ |------------:|----------:|----------:|------:|--------:|--------:|-------:|----------:|------------:|
| InterpolationToString   |    744.2 ns |   5.53 ns |   5.17 ns |  1.00 |    0.01 |  0.9842 |      - |   4.02 KB |        1.00 |
| OxpeckerToString        |  1,935.8 ns |   5.60 ns |   5.24 ns |  2.60 |    0.02 |  1.2207 |      - |   4.99 KB |        1.24 |
| GiraffeToString         |  2,660.5 ns |  10.37 ns |   8.10 ns |  3.58 |    0.03 |  3.7994 | 0.0038 |  15.55 KB |        3.86 |
| FalcoToString           |  2,429.5 ns |   8.68 ns |   8.12 ns |  3.26 |    0.02 |  1.8234 |      - |   7.46 KB |        1.85 |
| ScribanToString         | 18,797.9 ns | 115.96 ns | 108.47 ns | 25.26 |    0.22 |  9.7656 | 0.2441 |  40.11 KB |        9.97 |
| DotLiquidToString       | 47,442.3 ns | 122.76 ns | 114.83 ns | 63.75 |    0.45 | 10.1318 |      - |  41.45 KB |       10.30 |
| FluidToString           |  2,650.6 ns |  19.75 ns |  18.48 ns |  3.56 |    0.03 |  0.9575 |      - |   3.92 KB |        0.97 |
| RazorToString           |  9,464.8 ns | 107.87 ns |  95.62 ns | 12.72 |    0.15 |  1.2817 | 0.4272 |   7.91 KB |        1.97 |
| HandlebarsToString      |  1,659.2 ns |   2.49 ns |   2.33 ns |  2.23 |    0.02 |  0.4501 |      - |   1.84 KB |        0.46 |
| OxpeckerTweakedToString |    780.8 ns |   3.91 ns |   3.65 ns |  1.05 |    0.01 |  0.6590 |      - |    2.7 KB |        0.67 |
```