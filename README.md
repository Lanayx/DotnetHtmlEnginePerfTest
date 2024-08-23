```
BenchmarkDotNet v0.14.0, Windows 10
AMD Ryzen 7 2700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100-preview.7.24407.12
  [Host]     : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.40507), X64 RyuJIT AVX2


| Method             | Mean      | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|------------------- |----------:|----------:|----------:|-------:|-------:|----------:|
| OxpeckerToString   |  1.922 us | 0.0095 us | 0.0089 us | 1.1978 |      - |    4.9 KB |
| GiraffeToString    |  2.704 us | 0.0066 us | 0.0062 us | 3.7994 | 0.0038 |  15.55 KB |
| FalcoToString      |  2.439 us | 0.0178 us | 0.0158 us | 1.8234 |      - |   7.46 KB |
| ScribanToString    | 18.415 us | 0.1700 us | 0.1507 us | 9.6436 | 0.1221 |  39.48 KB |
| DotLiquidToString  | 47.453 us | 0.0875 us | 0.0775 us | 9.5215 |      - |  39.69 KB |
| FluidToString      |  1.721 us | 0.0119 us | 0.0111 us | 0.7839 |      - |    3.2 KB |
| RazorToString      |  9.578 us | 0.1049 us | 0.0876 us | 1.2512 | 0.4272 |   7.82 KB |
| HandlebarsToString |  1.666 us | 0.0116 us | 0.0108 us | 0.4501 |      - |   1.84 KB |
```