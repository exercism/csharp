# Performance

On the [approaches page][approaches], we described several approaches:

1. Using LINQ
2. Using `Array.Reverse()`
3. Using a `StringBuilder`

In this document, we'll find out which of these approaches is the most performant one.

Before we look at the numbers, let us look at another, less idiomatic approach.

## `Span<T>`

```exercism/note
C# 7.2. introduced the [`Span<T>`][span-t] class, which was specifically designed to allow performant iteration/mutation of _array-like_ objects.
The `Span<T>` class helps improve performance by always being allocated on the _stack_, and not the _heap_.
As objects on the stack don't need to be garbage collected, this can help improve performance (check [this blog post][using-span-t] for more information).
```

How can we leverage `Span<T>` to reverse our `string`?
The `string` class has an [`AsSpan()`][string-as-span] method, but that returns a `ReadOnlySpan<char>`, which doesn't allow mutation (otherwise we'd be able to indirectly modify the `string`).
We can work around this by manually allocating a `char[]` and assigning to a `Span<char>`:

```csharp
Span<char> chars = new char[input.Length];
for (var i = 0; i < input.Length; i++)
{
    chars[input.Length - 1 - i] = input[i];
}
return new string(chars);
```

After creating `Span<char>`, we use a regular `for`-loop to iterate over the string's characters and assign them to the right position in the span.
Finally, we can use the `string` constructor overload that takes a `Span<char>` to create the `string`.

However, this is basically the same approach as the `Array.Reverse()` approach, but with us also having to manually write a `for`-loop.
We _can_ do one better though, and that is to use [`stackalloc`][stackalloc].
With `stackalloc`, we can assign a block of memory _on the stack_ (whereas the array would be stored on the heap).

```csharp
Span<char> chars = stackalloc char[input.Length];
```

With this version, the memory allocated for the `Span<char>` is all on the stack and no garbage collection is needed for that data.

```exercism/caution
The stack has a finite amount of memory.
This means that for large strings, the above code will result in a `StackOverflowException` being thrown.

So what is the limit for the amount of memory we can allocate?
Well, this depends on how memory has already been allocated on the stack.
That said, a small test program successfully stack-allocated memory for `750_000` characters, so you might be fine.
```

## Benchmarks

To benchmark these approaches, we wrote a [small benchmark application][benchmark-dotnet-project] using [BenchmarkDotNet library][benchmark-dotnet].
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

1. `Span<T>`
2. `Array.Reverse()`
3. `StringBuilder`
4. LINQ

As can be seen, the LINQ-based approach is the slowest _and_ allocates the most memory.
In general, LINQ makes for highly readable code, but is usually not the most performance.

Using a `StringBuilder` is slightly better, but still quite a bit slower than the two top-performing approaches.

```exercism/note
It is worth noting, that the two slowest approachs (LINQ and `StringBuilder`) are also the ones that allocate (the most) memory.
Reducing memory allocation is often a great way to improve performance.
```

Clearly, the two top approaches are the `Array.Reverse()` and `Span<char>` approaches, with the latter being the best option.
The main difference between these two is heap vs stack memory allocation, which gives the `Span<char>` the slight edge. 🏆

[approaches]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches
[benchmark-dotnet]: https://benchmarkdotnet.org/index.html
[benchmark-dotnet-project]: https://github.com/exercism/csharp/tree/main/exercises/practice/reverse-string/.approaches/performance/benchmark
[stackalloc]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc
[using-span-t]: https://learn.microsoft.com/en-us/archive/msdn-magazine/2018/january/csharp-all-about-span-exploring-a-new-net-mainstay
[span-t]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1?view=net-6.0
[string-as-span]: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.asspan?view=net-6.0#system-memoryextensions-asspan(system-string)
