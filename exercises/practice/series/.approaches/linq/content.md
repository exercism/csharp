# LINQ

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static IEnumerable<string> Slices(string input, int length)
    {
        if (length < 1 || length > input.Length)
            throw new ArgumentException("Invalid length");

        return Enumerable.Range(0, input.Length - length + 1)
            .Select(i => input.Substring(i, length));
    }
}
```

The first step is to check the input for validity:

```csharp
if (length < 1 || length > input.Length)
    throw new ArgumentException("Invalid length");
```

Then we use [`Enumerable.Range()`][enumerable-range] to create the sequence of integers that represent the index from which we want to retrieve an individual slice:

```csharp
Enumerable.Range(0, input.Length - length + 1)
```

The tricky thing is to determine which indexes to return.
Let's look at an example input and some different slice lengths to examine which slice indexes we want to be getting the slice from:

| Input | Slice length | Slice indexes | Slices        |
| ----- | ------------ | ------------- | ------------- |
| "abc" | 1            | 0, 1, 2       | "a", "b", "c" |
| "abc" | 2            | 0, 1          | "ab", "bc"    |
| "abc" | 3            | 0             | "abc"         |

From this table, we can see the first slice index is always `0` and that `input length - slice length + 1` indexes are used.
Therefore, the `Enumerable.Range()` call starts at `0` and has returns `input.Length - length + 1` elements.

The final step is to map the indexes to the slices, for which we use [`Select()`][enumerable-select] and the [`Substring()`][string-substring] method:

```csharp
Select(i => input.Substring(i, length))
```

The value we're returning is the substring of the input that starts at index `i` and which has length equal to `length`.

## Shortening

The `Substring()` call could be replaced with a range call:

```csharp
input[i..(i + length)]
```

While slightly shorter, the fact that the parentheses are required makes this a minor gain.
In this case, the `Substring()` call probably better captures the domain logic, as it is more clear that we're return a string of size `length`.

[ranges]: https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
[yield-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range
[enumerable-select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[string-substring]: https://learn.microsoft.com/en-us/dotnet/api/system.string.substring
