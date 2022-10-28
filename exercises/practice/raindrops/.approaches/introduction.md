# Introduction

## General guidance

## Approach: `if` statements

```csharp
public static class Raindrops
{
    public string ConvertWithIfConcat()
    {
        var drops = "";
        if (number % 3 == 0)
            drops += "Pling";
        if (number % 5 == 0)
            drops += "Plang";
        if (number % 7 == 0)
            drops += "Plong";
        return drops.Length > 0 ? drops.ToString() : number.ToString();
    }
}
```

For more information, check the [`if` statements approach][approach-if-statements].

## Approach: `Aggregate` LINQ method

```csharp
using System.Linq;

public static class Raindrops
{
    private static readonly (int, string)[]  drips = { (3, "Pling"), (5, "Plang"), (7, "Plong") };

    public static string Convert(int number)
    {
        var drops = drips.Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2 : acc);
        return drops.Length > 0 ? drops : number.ToString();
    }
}
```

For more information, check the [`Aggregate` approach][approach-aggregate].

## Which approach to use?

[approach-if-statements]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/if-statements
[approach-aggregate]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/aggregate
