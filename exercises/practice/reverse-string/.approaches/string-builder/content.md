# StringBuilder

```csharp
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var chars = new StringBuilder();
        for (var i = input.Length - 1; i >= 0; i--)
        {
            chars.Append(input[i]);
        }
        return chars.ToString();
    }
}
```

Strings can also be created using the [`StringBuilder`][string-builder] class.
The purpose of this class is to efficiently and incrementally build a `string`.

```exercism/note
A `StringBuilder` is often overkill when used to create short strings, but can be very useful to create larger strings.
```

The first step is to create a `StringBuilder`.
We then use a `for`-loop to walk through the string's characters in reverse order, appending them to the `StringBuilder` via its [`Append()`][string-builder-append] method.

Finally, we return the reversed `string` by calling the `ToString()` method on the `StringBuilder` instance.

## Performance

If you're interested in how this approach's performance compares to other approaches, check the [performance approach][approach-performance].

[string-builder]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder
[string-builder-append]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append
[approach-performance]: https://exercism.org/tracks/csharp/exercises/reverse-string/articles/performance
