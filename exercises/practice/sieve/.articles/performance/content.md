# Performance

In this approach, we'll find out which sieve approach is the most efficient.

The [approaches page][approaches] lists two idiomatic approaches to this exercise:

1. [Using a `BitArray`][approach-bit-array].
2. [Using a `HashSet<T>`][approach-hash-set].

## Benchmarks

To benchmark the approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].

|   Method |  Max |         Mean |      Error |     StdDev |    Gen0 | Allocated |
| -------: | ---: | -----------: | ---------: | ---------: | ------: | --------: |
| BitArray |    1 |     55.04 ns |   0.102 ns |   0.095 ns |  0.0535 |     112 B |
|  HashSet |    1 |     26.61 ns |   0.114 ns |   0.101 ns |  0.0536 |     112 B |
| BitArray |   10 |    103.51 ns |   1.073 ns |   1.193 ns |  0.0726 |     152 B |
|  HashSet |   10 |    185.03 ns |   0.790 ns |   0.701 ns |  0.2027 |     424 B |
| BitArray | 1000 |  5,926.19 ns | 116.718 ns | 103.467 ns |  1.0452 |    2192 B |
|  HashSet | 1000 | 17,635.02 ns |  95.485 ns |  84.645 ns | 14.1907 |   29720 B |

We can see that, except for a very small maximum, the `BitArray` approach outperforms the `HashSet<T>` approach.
This makes sense, as the amount of memory allocated for the `BitArray` rises less steeply than the `HashSet<T>` due to its efficient nature.

[approaches]: https://exercism.org/tracks/csharp/exercises/sieve/approaches
[approach-bit-array]: https://exercism.org/tracks/csharp/exercises/sieve/approaches/bit-array
[approach-hash-set]: https://exercism.org/tracks/csharp/exercises/sieve/approaches/hash-set
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-application]: https://github.com/exercism/csharp/blob/main/exercises/practice/sieve/.articles/performance/code/Program.cs
