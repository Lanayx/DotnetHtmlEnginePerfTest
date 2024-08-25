```
BenchmarkDotNet v0.14.0, Windows 10
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2



| Method                  | Mean      | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|------------------------ |----------:|----------:|----------:|-------:|-------:|----------:|
| OxpeckerToString        |  1.877 us | 0.0095 us | 0.0084 us | 1.1978 |      - |    4.9 KB |
| GiraffeToString         |  2.720 us | 0.0168 us | 0.0149 us | 3.7994 | 0.0038 |  15.55 KB |
| FalcoToString           |  2.491 us | 0.0166 us | 0.0130 us | 1.8234 |      - |   7.46 KB |
| ScribanToString         | 17.627 us | 0.1996 us | 0.1867 us | 9.6436 | 0.1221 |  39.48 KB |
| DotLiquidToString       | 46.948 us | 0.1598 us | 0.1494 us | 9.5215 |      - |  39.69 KB |
| FluidToString           |  1.740 us | 0.0115 us | 0.0108 us | 0.7839 |      - |    3.2 KB |
| RazorToString           |  9.560 us | 0.1008 us | 0.0842 us | 1.2512 | 0.4272 |   7.82 KB |
| HandlebarsToString      |  1.702 us | 0.0086 us | 0.0080 us | 0.4501 |      - |   1.84 KB |
| OxpeckerTweakedToString |  1.177 us | 0.0166 us | 0.0147 us | 0.5836 |      - |   2.39 KB |
```