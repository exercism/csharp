# Introduction

The key to this exercise is use first calculate the distance from the center of the board, and then to check various boundary values to determine its score..

## Approach: if-statement

```csharp
public static int Score(double x, double y)
{
    var distanceFromCenter = Math.Sqrt(x * x + y * y);

    if (distanceFromCenter > 10.0)
        return 0;

    if (distanceFromCenter > 5.0)
        return 1;

    if (distanceFromCenter > 1.0)
        return 5;

    return 10;
}
```

This approach uses [`if` statements][if-statement] for the "distance from center" checks.
For more information, check the [`if` statements approach][approach-if-statements].

## Approach: `switch` expression

```csharp
public static int Score(double x, double y)
{
    return Math.Sqrt(x * x + y * y) switch
    {
        > 10.0 => 0,
        > 5.0 => 1,
        > 1.0 => 5,
        _ => 10
    };
}
```

This approach uses a [`switch` expression][switch-expression] and [relational patterns][relational-patterns] for the "distance from center" checks.
For more information, check the [`switch` expression approach][approach-switch-expression].

## Which approach to use?

Which to use is pretty much a matter of personal preference.

[approach-if-statements]: https://exercism.org/tracks/csharp/exercises/darts/approaches/if-statements
[approach-switch-expression]: https://exercism.org/tracks/csharp/exercises/darts/approaches/switch-expression
[switch-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[if-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-if-statement
[relational-patterns]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#relational-patterns
