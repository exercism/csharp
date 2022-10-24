|         Method |        Mean |     Error |    StdDev |   Gen0 | Allocated |
|--------------- |------------:|----------:|----------:|-------:|----------:|
| TotalWithRange | 2,060.88 ns | 21.030 ns | 17.561 ns | 0.0191 |     104 B |
|    TotalByBits |    59.15 ns |  0.446 ns |  0.417 ns | 0.0237 |     112 B |

Enumerating a `Range` from `1` to `64` to sum each call of `Square` (which uses `Pow`) is about thirty-five times slower than using bit shifting on `BigInteger`.
