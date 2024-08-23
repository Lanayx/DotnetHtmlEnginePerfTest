```
| Method             | Mean      | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|------------------- |----------:|----------:|----------:|-------:|-------:|----------:|
| OxpeckerToString   |  2.804 us | 0.0192 us | 0.0171 us | 1.4572 |      - |   5.95 KB |
| GiraffeToString    |  3.000 us | 0.0523 us | 0.0489 us | 3.9024 |      - |  15.97 KB |
| FalcoToString      |  2.690 us | 0.0270 us | 0.0253 us | 1.9569 |      - |      8 KB |
| ScribanToString    | 17.163 us | 0.3115 us | 0.2914 us | 9.5215 | 0.1221 |  39.35 KB |
| DotLiquidToString  | 47.943 us | 0.2037 us | 0.1906 us | 9.5215 |      - |  39.69 KB |
| FluidToString      |  1.679 us | 0.0071 us | 0.0067 us | 0.7839 |      - |    3.2 KB |
| RazorToString      |  9.596 us | 0.0837 us | 0.0699 us | 1.2512 | 0.4272 |   7.82 KB |
| HandlebarsToString |  1.691 us | 0.0108 us | 0.0101 us | 0.4501 |      - |   1.84 KB |
```