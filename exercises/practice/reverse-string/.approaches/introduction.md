# Introduction

The key to this exercise is to reverse a string's characters whilst C# strings being immutable.

## General guidance

- A `string`'s value cannot be changed (it is _immutable_). Therefore, to reverse a string you'll need to create a _new_ `string`.

- The most common way to create a new `string` (apart from hardcoding a string literal) is to call the [constructor that takes an array of characters][constructor-array-chars] (`char []`).

```exercism/note
C# strings represent text as a sequence of UTF-16 code units.
This means that you don't have to worry about multi-byte Unicode characters, as those are treated as one character.
```

## Approach: LINQ

```csharp
public static string Reverse(string input)
{
    return new string(input.Reverse().ToArray());
}
```

This approach uses LINQ to first reverse the `string` and then convert the reversed characters back to a `string`.
For more information, check the [LINQ approach][approach-linq].

## Approach: `Array.Reverse()`

```csharp
public static string Reverse(string input)
{
    var chars = input.ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
}
```

This approach uses the `Array.Reverse()` method to reverse a `char[]` copy of the string's character and then converts the reversed characters back to a `string`.
For more information, check the [`Array.Reverse()` approach][approach-array-reverse].

## Approach: `StringBuilder`

```csharp
public static string Reverse(string input)
{
    var chars = new StringBuilder();
    for (var i = input.Length - 1; i >= 0; i--)
    {
        chars.Append(input[i]);
    }
    return chars.ToString();
}
```

This approach iterates over the string's characters backwards, building up the reverse string using a `StringBuilder`.
For more information, check the [`StringBuilder` approach][approach-string-builder].

## Which approach to use?

If readability is your primary concern (and it usually should be), the LINQ-based approach is hard to beat.

The `Array.Reverse()` approach is the best performing apporach.
For a more detailed breakdown, check the [performance article][article-performance].

The `StringBuilder` approach has the worst performance of the listed approach, and is more error-prone to write as it has to deal with lower and upper bounds checking.

[constructor-array-chars]: https://learn.microsoft.com/en-us/dotnet/api/system.string.-ctor
[article-performance]: https://exercism.org/tracks/csharp/exercises/reverse-string/articles/performance
[approach-linq]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/linq
[approach-array-reverse]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/array-reverse
[approach-span]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/span
[approach-string-builder]: https://exercism.org/tracks/csharp/exercises/reverse-string/approaches/string-builder
