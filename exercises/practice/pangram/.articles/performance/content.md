
# Performance

In this approach, we'll find out how to most efficiently determine if a string is a Pangram in C#.

The [approaches page][approaches] lists two idiomatic approaches to this exercise:

1. [Using `All` with `Contains` on lowercased letters][approach-all-contains-tolower]
2. [Using `All` with `Contains` having case-insensitive comparison][approach-all-contains-case-insensitive]

For our performance investigation, we'll also include a third approach: [using a bit Field to keep track of used letters][approach-bitfield].

## Benchmarks

To benchmark the approaches, we wrote a small benchmark application using [BenchmarkDotNet library][benchmark-dotnet].

Each approach was benchmarked individually.

The first benchmarks were used to determine if there is a significant change between using the alpahbet inline, like so

```csharp
"abcdefghijklmnopqrstuvwxyz".All(c => input.Contains(c, xcase));
```

and defining the alphabet as a separate `const`, like so

```csharp
private const string Letters = "abcdefghijklmnopqrstuvwxyz";
// code snipped
Letters.All(c => input.Contains(c, xcase));
```

For case insenstive Contains:
- The top has the alphabet inline.
- The bottom has the alphabet defined as `const`.

|    Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
|---------- |---------:|----------:|----------:|-------:|----------:|
| IsPangram | 2.379 us | 0.0217 us | 0.0169 us | 0.0191 |      96 B |
| IsPangram | 2.392 us | 0.0079 us | 0.0066 us | 0.0191 |      96 B |

The two are essentially equivalent for performance.

This is the benchmark for `All` with `Contains` using `ToLower`

|    Method |     Mean |   Error |  StdDev |   Gen0 | Allocated |
|---------- |---------:|--------:|--------:|-------:|----------:|
| IsPangram | 348.3 ns | 1.51 ns | 1.26 ns | 0.0253 |     120 B |

`ToLower` is about seven times faster than using a case insensitive comparison.

Using a bit field

|    Method |     Mean |    Error |   StdDev | Allocated |
|---------- |---------:|---------:|---------:|----------:|
| IsPangram | 55.05 ns | 1.130 ns | 1.160 ns |         - |

Using a bit field is about six times faster than using `ToLower`, but it may be considered to be more idiomatic of the C language than C#.
Also, it depends on all of the letters being [ASCII][ascii].

[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[approaches]: https://exercism.org/tracks/csharp/exercises/pangram/approaches
[approach-all-contains-tolower]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-tolower
[approach-all-contains-case-insensitive]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/all-contains-case-insensitive
[approach-bitfield]: https://exercism.org/tracks/csharp/exercises/pangram/approaches/bitfield
[ascii]: https://www.asciitable.com/
