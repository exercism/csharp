# Span&lt;T&gt;

```csharp
Span<char> chars = stackalloc[input.Length];
for (var i = 0; i < input.Length; i++)
{
    chars[input.Length - 1 - i] = input[i];
}
return new string(chars);
```

C# 7.2. introduced the [`Span<T>`][span-t] class, which was specifically designed to allow performant iteration/mutation of _array-like_ objects.
The `Span<T>` class helps improve performance by always being allocated on the _stack_, and not the _heap_.
As objects on the stack don't need to be garbage collected, this can help improve performance (check [this blog post][using-span-t] for more information).

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
```

So what is the limit for the amount of memory we can allocate?
Well, this depends on how memory has already been allocated on the stack.
That said, a small test program successfully stack-allocated memory for `750_000` characters, so you might be fine.

## Performance

If you're interested in how this approach's performance compares to other approaches, check the [performance approach][approach-performance].

[stackalloc]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc
[using-span-t]: https://learn.microsoft.com/en-us/archive/msdn-magazine/2018/january/csharp-all-about-span-exploring-a-new-net-mainstay
[span-t]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1
[string-as-span]: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.asspan
[approach-performance]: https://exercism.org/tracks/csharp/exercises/reverse-string/articles/performance
