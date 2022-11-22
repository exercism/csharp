# Introduction

The key to this exercise is to traverse an array of string in _pairs_ (two adjacent elements), whilst allowing for the fact that the array might be empty.

## Approach: LINQ

```csharp
public static string[] Recite(string[] subjects)
{
    if (subjects.Length == 0)
        return Array.Empty<string>();

    return subjects.Zip(subjects.Skip(1))
        .Select((pair => $"For want of a {pair.First} the {pair.Second} was lost."))
        .Append($"And all for the want of a {subjects.First()}.")
        .ToArray();
}
```

This approach uses [LINQ][linq] to iterate over the subjects and compose the song's lines.
For more information, check the [LINQ approach][approach-linq].

## Approach: `for` loop

```csharp
public static string[] Recite(string[] subjects)
{
    if (subjects.Length > 0)
        return Array.Empty<string>();

    var lines = new string[subjects.Length];

    for (int i = 0; i < subjects.Length - 1; i++)
        lines[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";

    lines[^1] = $"And all for the want of a {subjects[0]}.";

    return lines;
}
```

This approach uses a [`for` loop][for-loop] to iterate over the subjects and compose the song's lines.
For more information, check the [`for` loop approach][approach-for-loop].

## Which approach to use?

The difference between the two approaches is mostly cosmetic, so what approach you prefer comes down to personal preference.

[approach-linq]: https://exercism.org/tracks/csharp/exercises/proverb/approaches/linq
[approach-for-loop]: https://exercism.org/tracks/csharp/exercises/proverb/approaches/for-loop
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[for-loop]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for
