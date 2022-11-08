# for-loop

```csharp
using System;
using System.Collections.Generic;

public static class Series
{
    public static IEnumerable<string> Slices(string input, int length)
    {
        if (length < 1 || length > input.Length)
            throw new ArgumentException("Invalid length");

        for (var i = 0; i <= input.Length - length; i++)
            yield return input.Substring(i, length);
    }
}
```

The first step is to check the input for validity:

```csharp
if (length < 1 || length > input.Length)
    throw new ArgumentException("Invalid length");
```

Then we iterate over the `input` parameter character by character:

```csharp
for (var i = 0; i <= input.Length - length; i++)
```

The tricky thing is to determine when to stop.
Let's look at an example input and some different slice lengths to examine which slice indexes we want to be getting the slice from:

| Input | Slice length | Slice indexes | Slices        |
| ----- | ------------ | ------------- | ------------- |
| "abc" | 1            | 0, 1, 2       | "a", "b", "c" |
| "abc" | 2            | 0, 1          | "ab", "bc"    |
| "abc" | 3            | 0             | "abc"         |

From this table, we can see the last slice index to use is `input length - slice length`.
Therefore, our loop's condition is `i <= input.Length - length`.

The final step is to return the slice, for which we use a [`yield` statement][yield-statement] and the [`Substring()` method][string-substring]:

```csharp
yield return input.Substring(i, length);
```

The value we're returning is the substring of the input that starts at index `i` and which has length equal to `length`.

The `yield` statement then returns the slice to the caller.
Even though we yield an indidivual string, what is returned from a caller's viewpoint is a sequence of strings.

```exercism/note
When a `yield` statement is written, the compiler transforms the method into a state machine that is suspended after each yield statement.
```

```exercism/note
Methods that use a `yield` statement are also _lazy_, which means that calling `Sequence(number)` by itself does not do anything.
It is only when a method is called that forces evaluation (like `Count()` or `ToArray()`), that we're forcing iteration over the elements in the sequence.
```

## Shortening

The `Substring()` call could be replaced with a range call:

```csharp
input[i..(i + length)]
```

While slightly shorter, the fact that the parentheses are required makes this a minor gain.
In this case, the `Substring()` call probably better captures the domain logic, as it is more clear that we're return a string of size `length`.

[ranges]: https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
[yield-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
[string-substring]: https://learn.microsoft.com/en-us/dotnet/api/system.string.substring
