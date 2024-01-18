# Introduction

There are various idioomatic ways to solve Raindrops.
You can use a series of `if` statements.
Or you can use the LINQ method `Aggregate` on an array of tuples.

## General guidance

The key to solving Raindrops is to know if the input is evenly divisible by `3`, `5` and/or `7`.
For determining that, you will use the the [remainder operator][remainder-operator].

## Approach: `if` statements

```csharp
public static string Convert(int number)
{
    var drops = "";

    if (number % 3 == 0) drops += "Pling";
    if (number % 5 == 0) drops += "Plang";
    if (number % 7 == 0) drops += "Plong";

    return drops.Length > 0 ? drops : number.ToString();
}
```

This approach uses a series of `if`-statements and string concatentation to build up the result string.
For more information, check the [`if` statements approach][approach-if-statements].

## Approach: `StringBuilder`

```csharp
public static string Convert(int number)
{
    var drops = new StringBuilder(15);

    if (number % 3 == 0) drops.Append("Pling");
    if (number % 5 == 0) drops.Append("Plang");
    if (number % 7 == 0) drops.Append("Plong");

    return drops.Length > 0 ? drops.ToString() : number.ToString();
}
```

This approach uses a series of `if`-statements and a `StringBuilder` to build up the result string.
For more information, check the [`StringBuilder` approach][approach-string-builder].

## Approach: `Aggregate` LINQ method

```csharp
public static string Convert(int number)
{
    var drips = new[]{ (3, "Pling"), (5, "Plang"), (7, "Plong") };
    var drops = drips.Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2 : acc);
    return drops.Length > 0 ? drops : number.ToString();
}
```

This approach uses LINQ to filter the right sounds.
For more information, check the [`Aggregate` approach][approach-aggregate].

## Approach: pattern matching

```csharp
public static string Convert(int number) =>
    (number % 3, number % 5, number % 7) switch
    {
        (0, 0, 0) => "PlingPlangPlong",
        (0, 0, _) => "PlingPlang",
        (0, _, 0) => "PlingPlong",
        (_, 0, 0) => "PlangPlong",
        (0, _, _) => "Pling",
        (_, 0, _) => "Plang",
        (_, _, 0) => "Plong",
        _ => number.ToString()
    };
```

This approach uses pattern matching on a tuple to find the matching sounds.
For more information, check the [pattern matching approach][approach-pattern-matching].

## Which approach to use?

Although the `Aggregate` approach may be considered more "functional", it is about three times slower than the `if` statements approach.

[remainder-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-
[approach-if-statements]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/if-statements
[approach-aggregate]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/aggregate
[approach-string-builder]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/string-builder
[approach-pattern-matching]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/pattern-matching
