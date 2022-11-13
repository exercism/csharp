# Array.Reverse

```csharp
using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
```

The `string` class' [`ToCharArray()`][to-char-array] method returns the string's characters as a `char[]`.

```exercism/caution
The `char[]` returned by `ToCharArray()` is a **copy** of the `string`'s characters.
Modifying the values in the `char[]` does **not** update the `string` it was created from.
```

We then pass the `char[]` to the [`Array.Reverse()`][array-reverse] method, which will reverse the array's content _in-place_ (meaning the argument is modified).

Finally, we return the reversed `string` by calling its constructor with the (reversed) `char[]`.

## Performance

If you're interested in how this approach's performance compares to other approaches, check the [performance approach][approach-performance].

[to-char-array]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tochararray
[array-reverse]: https://learn.microsoft.com/en-us/dotnet/api/system.array.reverse
[approach-performance]: https://exercism.org/tracks/csharp/exercises/reverse-string/articles/performance
