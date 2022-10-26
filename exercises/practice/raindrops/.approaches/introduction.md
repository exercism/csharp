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
using System.Collections.Generic;

public static class Raindrops
{
    public static string Convert(int number)
    {
        var drops =  (new List<(int, string)>{(3, "Pling"), (5, "Plang"), (7, "Plong")})
            .Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2: acc);
        return drops != "" ? drops: number.ToString();
    }
}
```

For more information, check the [`Aggregate` approach][approach-aggregate].

## Which approach to use?

(Stowing benchmarks here for now)

|               Method |      Mean |    Error |   StdDev |   Gen0 | Allocated |
|--------------------- |----------:|---------:|---------:|-------:|----------:|
|  ConvertWithIfConcat |  24.78 ns | 0.154 ns | 0.144 ns | 0.0221 |     104 B |
| ConvertWithIfBuilder |  36.93 ns | 0.292 ns | 0.244 ns | 0.0340 |     160 B |
|     ConvertAggConcat | 129.85 ns | 1.430 ns | 1.194 ns | 0.0713 |     336 B |
|    ConvertAggBuilder | 130.75 ns | 1.209 ns | 1.072 ns | 0.0832 |     392 B |

[approach-if-statements]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/if-statements
[approach-aggregate]: https://exercism.org/tracks/csharp/exercises/raindrops/approaches/aggregate