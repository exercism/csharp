# Performance

In this approach, we'll find out how to most efficiently solve Protein Translation in C#.

The [approaches page][approaches] lists five idiomatic approaches to this exercise:

1. [Using `Substring()` with a `Dictionary`][approach-substring-dict].
2. [Using `Substring()` with a `switch`][approach-substring-switch].
3. [Using LINQ with a `Dictionary`][approach-linq-dict].
4. [Using `yield` with a `Dictionary`][approach-yield-dict].
5. [Using `yield` with a `switch`][approach-yield-switch].

## Benchmarks

To benchmark the approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].

|                  Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------------ |----------:|---------:|---------:|-------:|----------:|
|   ProteinsSubstringDict | 128.69 ns | 0.517 ns | 0.432 ns | 0.0560 |     264 B |
| ProteinsSubstringSwitch |  91.59 ns | 1.426 ns | 1.264 ns | 0.0560 |     264 B |
|        ProteinsLinqDict | 453.59 ns | 1.114 ns | 1.042 ns | 0.1254 |     592 B |
|       ProteinsYieldDict | 313.60 ns | 1.537 ns | 1.284 ns | 0.0901 |     424 B |
|     ProteinsYieldSwitch | 270.33 ns | 2.731 ns | 2.554 ns | 0.0901 |     424 B |

Iterating by `Substring`s and looking up the values in a `switch` was the fastest approach.

[approaches]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches
[approach-substring-dict]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/substring-dict
[approach-substring-switch]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/substring-switch
[approach-linq-dict]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/linq-dict
[approach-yield-dict]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/yield-dict
[approach-yield-switch]: https://exercism.org/tracks/csharp/exercises/protein-translation/approaches/yield-switch
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-application]: https://github.com/exercism/csharp/blob/main/exercises/practice/protein-translation/.articles/performance/code/Program.cs
