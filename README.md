```
| Method            | Mean      | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|------------------ |----------:|----------:|----------:|-------:|-------:|----------:|
| OxpeckerToString  |  2.737 us | 0.0055 us | 0.0049 us | 1.4572 |      - |   5.95 KB |
| GiraffeToString   |  2.978 us | 0.0167 us | 0.0148 us | 3.9024 |      - |  15.97 KB |
| FalcoToString     |  2.691 us | 0.0266 us | 0.0236 us | 1.9569 |      - |      8 KB |
| ScribanToString   | 17.472 us | 0.1881 us | 0.1570 us | 9.6436 | 0.1221 |  39.48 KB |
| DotLiquidToString | 47.297 us | 0.1923 us | 0.1799 us | 9.5215 |      - |  39.69 KB |
| FluidToString     |  1.665 us | 0.0061 us | 0.0055 us | 0.7839 |      - |    3.2 KB |
| RazorToString     |  9.708 us | 0.1917 us | 0.1793 us | 1.2512 | 0.4272 |   7.82 KB |

```