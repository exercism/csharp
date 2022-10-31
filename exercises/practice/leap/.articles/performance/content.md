# Performance

In this approach, we'll find out how to most efficiently calculate if a year is a leap year in C#.

The [approaches page][approaches] lists three idiomatic approaches to this exercise:

1. [Using the boolean chain][approach-boolean-chain]
2. [Using the ternary operator][approach-ternary-operator]
3. [Using `switch` in a `tuple`][approach-switch-on-a-tuple]

## Benchmarks

To benchmark the approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].


|            Method | testYear |      Mean |     Error |    StdDev | Allocated |
|------------------ |--------- |----------:|----------:|----------:|----------:|
|   IsLeapYearChain |     1900 | 1.0503 ns | 0.0127 ns | 0.0106 ns |         - |
| IsLeapYearTernary |     1900 | 0.8741 ns | 0.0071 ns | 0.0063 ns |         - |
|  IsLeapYearSwitch |     1900 | 2.2732 ns | 0.0313 ns | 0.0278 ns |         - |
|   IsLeapYearChain |     2000 | 1.0636 ns | 0.0106 ns | 0.0099 ns |         - |
| IsLeapYearTernary |     2000 | 0.8842 ns | 0.0073 ns | 0.0065 ns |         - |
|  IsLeapYearSwitch |     2000 | 2.2936 ns | 0.0436 ns | 0.0408 ns |         - |
|   IsLeapYearChain |     2019 | 1.0601 ns | 0.0216 ns | 0.0191 ns |         - |
| IsLeapYearTernary |     2019 | 0.9048 ns | 0.0503 ns | 0.1215 ns |         - |
|  IsLeapYearSwitch |     2019 | 2.4466 ns | 0.0779 ns | 0.1236 ns |         - |
|   IsLeapYearChain |     2020 | 1.0490 ns | 0.0154 ns | 0.0137 ns |         - |
| IsLeapYearTernary |     2020 | 1.1003 ns | 0.0230 ns | 0.0216 ns |         - |
|  IsLeapYearSwitch |     2020 | 2.7031 ns | 0.0821 ns | 0.1229 ns |         - |

You can see that the ternary operator was a _bit_ faster than the chain of conditions for three of the four tested years,
but there was always only a fraction of a nanosecond difference between them.

Although it may be considered the most "functional" approach, the `switch` on a `tuple` was consistently slower than the other approaches.

[approaches]: https://exercism.org/tracks/csharp/exercises/leap/approaches
[approach-boolean-chain]: https://exercism.org/tracks/csharp/exercises/leap/approaches/boolean-chain
[approach-ternary-operator]: https://exercism.org/tracks/csharp/exercises/leap/approaches/ternary-operator
[approach-switch-on-a-tuple]: https://exercism.org/tracks/csharp/exercises/leap/approaches/switch-on-a-tuple
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-application]: https://github.com/exercism/csharp/blob/main/exercises/practice/leap/.articles/performance/code/Program.cs
