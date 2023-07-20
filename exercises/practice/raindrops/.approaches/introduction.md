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
    if (number % 3 == 0)
        drops += "Pling";
    if (number % 5 == 0)
        drops += "Plang";
    if (number % 7 == 0)
        drops += "Plong";
    return drops.Length > 0 ? drops : number.ToString();
}
```

For more information, check the [`if` statements approach][approach-if-statements].

## Approach: `Aggregate` LINQ method

```csharp
public static string Convert(int number)
{
    var drips = new[]{ (3, "Pling"), (5, "Plang"), (7, "Plong") };
    var drops = drips.Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2 : acc);
    return drops.Length > 0 ? drops : number.ToString();
}
```

For more information, check the [`Aggregate` approach][approach-aggregate].

## Which approach to use?

Although the `Aggregate` approach may be considered moe "functional", it is about three times slower than the `if` statements approach.

[remainder-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-
[approach-if-statements]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/if-statements
[approach-aggregate]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/aggregate
