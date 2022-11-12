# Introduction

The key to this exercise is to iterate over a string and return slices (_substrings_) of a specified length for that string.

## General guidance

- It can help to choose one example input string and write out at what index you should return slices of that string for a given slice length

## Approach: `for` loop

```csharp
public static IEnumerable<string> Slices(string input, int length)
{
    if (length < 1 || length > input.Length)
        throw new ArgumentException("Invalid length");

    for (var i = 0; i <= input.Length - length; i++)
        yield return input.Substring(i, length);
}
```

This approach uses a [`for` loop][for-loop] to iterate over the string and return its slices.
For more information, check the [for-loop approach][approach-for-loop].

## Approach: LINQ

```csharp
public static IEnumerable<string> Slices(string input, int length)
{
    if (length < 1 || length > input.Length)
        throw new ArgumentException("Invalid length");

    return Enumerable.Range(0, input.Length - length + 1)
        .Select(i => input.Substring(i, length));
}
```

This approach uses [LINQ][linq] to iterate over the string and return its slices.
For more information, check the [LINQ approach][approach-linq].

## Which approach to use?

The difference between the two approaches is mostly cosmetic, apart from the fact that the `for` loop approach returns a _lazy_ sequence, which means that for larger inputs it will use (far) less memory.

[approach-for-loop]: https://exercism.org/tracks/csharp/exercises/series/approaches/for-loop
[approach-linq]: https://exercism.org/tracks/csharp/exercises/series/approaches/linq
[for-loop]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
