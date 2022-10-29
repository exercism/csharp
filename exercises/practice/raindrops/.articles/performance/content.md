# Performance

In this approach, we'll find out how to most efficiently calculate Raindrops in C#.

The [approaches page][approaches] lists two idiomatic approaches to this exercise:

1. [Using if statements][approach-if-statements]
2. [Using the ternary operator][approach-aggregate]

## Benchmarks

To benchmark the approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].

|               Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|--------------------- |----------:|---------:|---------:|-------:|----------:|
|  ConvertWithIfConcat |  24.78 ns | 0.154 ns | 0.144 ns | 0.0221 |     104 B |
| ConvertWithIfBuilder |  36.93 ns | 0.292 ns | 0.244 ns | 0.0340 |     160 B |
|     ConvertAggConcat | 129.85 ns | 1.430 ns | 1.194 ns | 0.0713 |     336 B | 
|    ConvertAggBuilder | 130.75 ns | 1.209 ns | 1.072 ns | 0.0832 |     392 B | 
|      ConvertAggArray |  85.58 ns | 0.467 ns | 0.414 ns | 0.0577 |     272 B |
|     ConvertAggSepAry |  76.42 ns | 0.200 ns | 0.167 ns | 0.0424 |     200 B |

The `if` statements approach was tried using concatenation and using [StringBuilder][stringbuilder].
It takes some time to set up a `StringBuilder`.
When that time is divided by many multiple appends, the `StringBuilder` can be more efficient than concatenating.
For Raindrops, the most concatenations you'll have will be three.
So, while another solution is setting up the `StringBuilder` you can be well on your way to concatenating just three values.

For the `Aggregate` approach iterating on a `List`, it takes so long to set up the `List` that the set up time for `StringBuilder`
has no significant impact on the performance.
Since the `Aggregate` approach  is about five times slower than the `if` statements approach,
the choice of concatenation or `StringBuilder` for `Aggregate` makes little difference anyway.

The `Aggregate` approach using an [Array][arrays] which is defined inline is over three times slower than the `if` statements approach.
That's better than being five times slower, but it is still significantly slower.

The `Aggregate` approach using an [Array][arrays] which is defined outside of the function as [readonly][readonly]
is just about three times slower than the `if` statements approach.
So even through the `Aggregate` approach with an `Array` is almost twice as fast as the `Aggregate` approach with a `List`,
it is still significantly slower than the `if` statements approach.

[approaches]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches
[approach-if-statements]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/if-statements
[approach-aggregate]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/aggregate
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-application]: https://github.com/exercism/csharp/blob/main/exercises/practice/raindrops/.articles/performance/code/Program.cs
[stringbuilder]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder
[list]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
[arrays]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
[readonly]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly
