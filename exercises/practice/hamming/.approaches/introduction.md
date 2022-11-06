# Introduction

The key to this exercise is to be able to compare two strings, character by character, at the same time.

## General guidance

- If you check the strings for equal lengths at the start of the method, you can safely iterate over both strings in a single loop

## Approach: LINQ

```csharp
public static int Distance(string strand1, string strand2)
{
    if (strand1.Length != strand2.Length)
        throw new ArgumentException("Strands have different length");

    return strand1.Zip(strand2).Count(pair => pair.First != pair.Second);
}
```

This approach uses LINQ to _zip_ the two strings together and then counting the number of character pairs where their value is different.
For more information, check the [LINQ approach][approach-linq].

## Approach: `for`-loop

```csharp
public static int Distance(string strand1, string strand2)
{
    if (strand1.Length != strand2.Length)
        throw new ArgumentException("Strands have different length");

    var distance = 0;

    for (var i = 0; i < strand1.Length; i++)
    {
        if (strand1[i] != strand2[i])
            distance++;
    }

    return distance;
}
```

This approach uses a [`for`-loop][for-statement] to iterate over both strings at the same time, increment a counter when the values at the current index are unequal.
For more information, check the [`for`-loop approach][approach-for-loop].

## Which approach to use?

The difference between the two approaches mostly cosmetic, so what approach you prefer comes down to personal preference.

[approach-linq]: https://exercism.org/tracks/csharp/exercises/hamming/approaches/linq
[approach-for-loop]: https://exercism.org/tracks/csharp/exercises/hamming/approaches/for-loop
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[for-statement]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for
