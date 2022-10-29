# Performance

In this approach, we'll find out how to most efficiently calculate the value for Grains in C#.

The [approaches page][approaches] lists two idiomatic approaches to this exercise:

1. [Using `Pow`][approach-pow]
2. [Using bit shifting][approach-bit-shifting]

## Benchmarks

To benchmark the approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].

|         Method |        Mean |     Error |    StdDev |   Gen0 | Allocated |
|--------------- |------------:|----------:|----------:|-------:|----------:|
| TotalWithRange | 2,060.88 ns | 21.030 ns | 17.561 ns | 0.0191 |     104 B |
|    TotalByBits |    59.15 ns |  0.446 ns |  0.417 ns | 0.0237 |     112 B |

Enumerating a `Range` from `1` to `64` to sum each call of `Square` (which uses `Pow`) is about thirty-five times slower than using bit shifting on `BigInteger`.

[approaches]: https://exercism.org/tracks/csharp/exercises/grains/approaches
[approach-pow]: https://exercism.org/tracks/csharp/exercises/grains/approaches/pow
[approach-bit-shifting]: https://exercism.org/tracks/csharp/exercises/grains/approaches/bit-shifting
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-application]: https://github.com/exercism/csharp/blob/main/exercises/practice/grains/.articles/performance/code/Program.cs
