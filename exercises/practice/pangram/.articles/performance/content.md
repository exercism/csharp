
# Performance

In this approach, we'll find out how to most efficiently determine if a string is a Pangram in C#.

The [approaches page][approaches] lists two idiomatic approaches to this exercise:

1. [Using `All` with `Contains` on lowercased letters][approach-all-contains-tolower]
2. [Using `All` with `Contains` having case-insensitive comparison][approach-all-contains-case-insensitive]

For our performance investigation, we'll also include a third approach: [using a bit Field to keep track of used letters][approach-bitfield].

## Benchmarks

To benchmark the approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].

|               Method |        Mean |     Error |   StdDev |   Gen0 | Allocated |
|--------------------- |------------:|----------:|---------:|-------:|----------:|
|     IsPangramLowered |   358.89 ns |  2.771 ns | 2.456 ns | 0.0253 |     120 B |
| IsPangramInsensitive | 2,355.36 ns | 11.867 ns | 9.910 ns | 0.0191 |      96 B |
|    IsPangramBitfield |    54.71 ns |  0.543 ns | 0.508 ns |      - |         - |

Comparing the lower-cased characters is over six times faster than doing a case-insensitive comparison.
Using a bit field is more than six times faster than using `ToLower`, but it may be considered to be more idiomatic of the C language than C#.

[benchmark-application]: https://github.com/exercism/csharp/blob/main/exercises/practice/pangram/.articles/performance/code/Program.cs
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[approaches]: https://exercism.org/tracks/csharp/exercises/pangram/approaches
[approach-all-contains-tolower]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-tolower
[approach-all-contains-case-insensitive]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-case-insensitive
[approach-bitfield]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/bitfield
[ascii]: https://www.asciitable.com/
