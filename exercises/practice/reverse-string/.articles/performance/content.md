# Performance

In this approach, we'll find out how to most efficiently reverse a string in C#.

The [approaches page][approaches] lists three idiomatic approaches to this exercise:

1. [Using LINQ][approach-linq]
2. [Using `Array.Reverse()`][approach-array-reverse]
3. [Using `StringBuilder`][approach-string-builder]

For our performance investigation, we'll also include a fourth approach that [uses `Span<T>`][approach-span].

## Benchmarks

To benchmark these approaches, we wrote a [small benchmark application][benchmark-application] using [BenchmarkDotNet library][benchmark-dotnet].
The benchmark checks the various approaches against strings of length `0`, `10`, `100` and `100_000`.
Besides the regular CPU-time columns, the amount of memory used was also tracked.

These are the results:

|        Method | Length |      Mean |     Error |    StdDev |    Median |   Gen0 | Allocated |
| ------------: | -----: | --------: | --------: | --------: | --------: | -----: | --------: |
|          Linq |      0 | 29.133 ns | 0.5865 ns | 0.5486 ns | 28.984 ns | 0.0061 |      80 B |
|  ArrayReverse |      0 |  4.806 ns | 0.4999 ns | 1.4739 ns |  3.967 ns |      - |         - |
| StringBuilder |      0 |  7.424 ns | 0.1731 ns | 0.1534 ns |  7.418 ns | 0.0080 |     104 B |
|          Span |      0 |  2.326 ns | 0.0599 ns | 0.0531 ns |  2.329 ns |      - |         - |
|          Linq |     10 | 26.671 ns | 0.2198 ns | 0.1948 ns | 26.653 ns | 0.0061 |      80 B |
|  ArrayReverse |     10 |  4.022 ns | 0.0523 ns | 0.0490 ns |  4.035 ns |      - |         - |
| StringBuilder |     10 |  7.449 ns | 0.1955 ns | 0.2472 ns |  7.360 ns | 0.0080 |     104 B |
|          Span |     10 |  2.262 ns | 0.0525 ns | 0.0492 ns |  2.250 ns |      - |         - |
|          Linq |    100 | 26.997 ns | 0.4535 ns | 0.4242 ns | 26.982 ns | 0.0061 |      80 B |
|  ArrayReverse |    100 |  3.989 ns | 0.0941 ns | 0.0880 ns |  4.027 ns |      - |         - |
| StringBuilder |    100 | 13.549 ns | 1.4400 ns | 4.2460 ns | 16.309 ns | 0.0080 |     104 B |
|          Span |    100 |  2.221 ns | 0.0382 ns | 0.0339 ns |  2.218 ns |      - |         - |
|          Linq | 100000 | 26.664 ns | 0.4895 ns | 0.4339 ns | 26.556 ns | 0.0061 |      80 B |
|  ArrayReverse | 100000 |  6.004 ns | 0.1859 ns | 0.2545 ns |  6.056 ns |      - |         - |
| StringBuilder | 100000 | 16.601 ns | 0.3820 ns | 0.7540 ns | 16.746 ns | 0.0080 |     104 B |
|          Span | 100000 |  6.013 ns | 0.1711 ns | 0.3336 ns |  6.085 ns |      - |         - |

The final rankings are:

1. [Using `Span<T>`][approach-span]
2. [Using `Array.Reverse()`][approach-array-reverse]
3. [Using `StringBuilder`][approach-string-builder]
4. [Using LINQ][approach-linq]

### Span&lt;T&gt;

The top performing approach is the `Span<T>` approach.
This is due to us allocating the `char []` on the stack and not on the heap.
Stack access is both faster than heap access and does not require garbage collection.

The main downside is that the stack has a relatively small amount of memory, so for very large strings you'll get a `StackOverflowException`.

### Array.Reverse

The `Array.Reverse()` call has very similar performance characteristics to the `Span<T>` approach.
This is not coincidental, as `Array.Reverse()` actually [uses `Span<T>` internally][src-array-reverse]:

```csharp
case CorElementType.ELEMENT_TYPE_CHAR:
    UnsafeArrayAsSpan<short>(array, adjustedIndex, length).Reverse();
    return;
```

The main reason why it is slower than the `Span<T>` approach, is that the `ToCharArray()` call [allocates a `char[]` on the heap][src-to-char-array], which is slower to access and needs to be garbage collected:

```csharp
char[] chars = new char[Length];
```

### LINQ

The LINQ-based approach is the slowest _and_ allocates the most memory.
In general, LINQ makes for highly readable code, but is usually not the most performance.

### StringBuilder

The `StringBuilder` approach is slightly better, but still quite a bit slower than the two top-performing approaches.
It also allocates the most memory of all the approaches.

One common way to optimize performance when using a `StringBuilder` is to set its internal buffer's capacity to a value that won't be exceeded:

```csharp
var chars = new StringBuilder(capacity: input.Length);
```

Unfortunately, in this case this does not give us any performance benefit:

|                Method | Length |     Mean |    Error |   StdDev |   Gen0 | Allocated |
| --------------------: | -----: | -------: | -------: | -------: | -----: | --------: |
|         StringBuilder |      0 | 13.00 ns | 0.311 ns | 0.635 ns | 0.0080 |     104 B |
| StringBuilderCapacity |      0 | 15.18 ns | 0.354 ns | 0.664 ns | 0.0080 |     104 B |
|         StringBuilder |     10 | 13.75 ns | 0.323 ns | 0.331 ns | 0.0080 |     104 B |
| StringBuilderCapacity |     10 | 15.28 ns | 0.354 ns | 0.508 ns | 0.0080 |     104 B |
|         StringBuilder |    100 | 13.00 ns | 0.307 ns | 0.545 ns | 0.0080 |     104 B |
| StringBuilderCapacity |    100 | 15.13 ns | 0.352 ns | 0.844 ns | 0.0080 |     104 B |
|         StringBuilder | 100000 | 13.25 ns | 0.311 ns | 0.656 ns | 0.0080 |     104 B |
| StringBuilderCapacity | 100000 | 14.99 ns | 0.345 ns | 0.631 ns | 0.0080 |     104 B |

## Conclusion

The top performing approaches are the `Span<T>` and `Array.Reverse()` approaches.
The `Span<T>` approach has the downside of being more error-prone to write and from not working for all inputs, but it is the fastest approach. 🏆

The two slowest approaches, LINQ and `StringBuilder`, are also the ones that allocate (the most) memory.

```exercism/note
Reducing memory allocation is often a great way to improve performance.
```

[approaches]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches
[approach-linq]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/linq
[approach-array-reverse]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/array-reverse
[approach-span]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/span
[approach-string-builder]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/string-builder
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-application]: https://github.com/exercism/csharp/blob/main/exercises/practice/reverse-string/.articles/performance/code/Program.cs
[src-array-reverse]: https://cs.github.com/dotnet/runtime/blob/12f9f91031224a45c146812a7f4a41e8cdb87e1c/src/libraries/System.Private.CoreLib/src/System/Array.cs#L1663-L1698
[src-to-char-array]: https://cs.github.com/dotnet/runtime/blob/12f9f91031224a45c146812a7f4a41e8cdb87e1c/src/libraries/System.Private.CoreLib/src/System/String.cs?q=path%3A%2F%5Esrc%5C%2Flibraries%5C%2FSystem.Private.CoreLib%5C%2Fsrc%5C%2FSystem%2F+string#L451
