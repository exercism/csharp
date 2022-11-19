# LINQ

```csharp
using System.Linq;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        return new string(input.Reverse().ToArray());
    }
}
```

The `string` class implements the `IEnumerable<char>` interface, which allows us to call [LINQ][linq]'s [`Reverse()`][linq-reverse] extension method on it.

To convert the `IEnumerable<char>` returned by `Reverse()` back to a `string`, we first use [`ToArray()`][linq-to-array] to convert it to a `char[]`.

Finally, we return the reversed `string` by calling its constructor with the (reversed) `char[]`.

## Shortening

There are two things we can do to further shorten this method:

1. Remove the curly braces by converting to an [expression-bodied method][expression-bodied-method]
1. Use a [target-typed new][target-typed-new] expression to replace `new string` with just `new` (the compiler can figure out the type from the method's return type)

Using this, we end up with:

```csharp
public static string Reverse(string input) => new(input.Reverse().ToArray());
```

## Performance

If you're interested in how this approach's performance compares to other approaches, check the [performance approach][approach-performance].

[linq-reverse]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.reverse
[linq-to-array]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray
[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[approach-performance]: https://exercism.org/tracks/csharp/exercises/reverse-string/articles/performance
