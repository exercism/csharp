# Introduction

The key to this exercise is to deal with C# strings being immutable, which means that a `string`'s value cannot be changed.
Therefore, to reverse a string you'll need to create a _new_ `string`.

The most common way to create a new `string` (apart from hardcoding a string literal) is to call the [constructor that takes an array of characters][constructor-array-chars] (`char []`).

```exercism/note
C# strings represent text as a sequence of UTF-16 code units.
This means that you don't have to worry about multi-byte Unicode characters, as those are treated as one character.
```

## Using LINQ

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

### Shortening

There are two things we can do to further shorten this method:

1. Remove the curly braces by converting to an [expression-bodied method][expression-bodied-method]
1. Use a [target-typed new][target-typed-new] expression to replace `new string` with just `new` (the compiler can figure out the type from the method's return type)

Using this, we end up with:

```csharp
public static string Reverse(string input) => new(input.Reverse().ToArray());
```

## Using `Array.Reverse`

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
Modifying the values in the `char[]` does not update the `string` it was created from.
```

We then pass the `char[]` to the [`Array.Reverse()`][array-reverse] method, which will reverse the array's content _in-place_ (meaning the argument is modified).

Finally, we return the reversed `string` by calling its constructor with the (reversed) `char[]`.

## Using `StringBuilder`

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

## Which approach to use?

The above three approaches are all valid approaches, but the first two are:

- Arguably more readable
- Less error-prone (they don't have to deal with upper and lower bounds as the `for`-loop does)

If readability is your primary concern (and it usually should be), the LINQ-based approach is hard to beat.
However, if you care about performance, the `Array`-based option is preferrable, especially when dealing with longer strings.
For a more detailed analysis on the performance, check out the [performance approach][performance-approach] page.

[string-builder]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=net-7.0
[linq-reverse]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.reverse?view=net-7.0
[linq-to-array]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray?view=net-7.0
[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[constructor-array-chars]: https://learn.microsoft.com/en-us/dotnet/api/system.string.-ctor?view=net-7.0#system-string-ctor(system-char())
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[to-char-array]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tochararray?view=net-6.0
[array-reverse]: https://learn.microsoft.com/en-us/dotnet/api/system.array.reverse?view=net-6.0
[target-typed-new]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
[string-builder-append]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append?view=net-7.0#system-text-stringbuilder-append(system-char)
[performance-approach]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/performance
