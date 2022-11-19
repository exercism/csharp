# Introduction

There are various idiomatic approaches to solve Leap.
You can use a chain of boolean expressions to test the conditions.
Or you can use a [ternary operator][ternary-operator].
Another approach you can use is a [switch][switch] on a [tuple][tuple].

## General guidance

The key to solving Leap is to know if the year is evenly divisible by `4`, `100` and `400`.
For determining that, you will use the [remainder operator][remainder-operator].

## Approach: Chain of Boolean expressions

```csharp
public static bool IsLeapYear(int year)
{
    return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
}
```

For more information, check the [Boolean chain approach][approach-boolean-chain].

## Approach: Ternary operator of Boolean expressions

```csharp
public static bool IsLeapYear(int year)
{
    return year % 100 == 0 ? year % 400 == 0 : year % 4 == 0;
}
```

For more information, check the [Ternary operator approach][approach-ternary-operator].

## Approach: `switch` on a `tuple`

```csharp
public static bool IsLeapYear(int year)
{
    return (year % 4, year % 100, year % 400) switch
    {
        (_, 0, 0) => true,
        (_, 0, _) => false,
        (0, _, _) => true,
        _ => false,
    };
}
```

For more information, check the [`switch` on a `tuple` approach][approach-switch-on-a-tuple].

## Other approaches

Besides the aforementioned, idiomatic approaches, you could also approach the exercise as follows:

## DateTime.Add approach:

Add a day to February 28th for the year and see if the new day is the 29th. For more information, see the [`DateTime.Add` approach][approach-datetime-add].

## Built-in method approach:

Use the built-in method for the year. For more information, see the [`DateTime.IsLeapYear` approach][approach-datetime-isleapyear].

## Which approach to use?

- The chain of boolean expressions is most efficient, as it proceeds from the most likely to least likely conditions.
  It has a maximum of three checks.
- The ternary operator has a maximum of only two checks, but it starts from a less likely condition.
- The `switch` on a `tuple` may be considered more "functional", but it is more verbose and may be considered less readable.
- Using DateTime addition or using the built-in `IsLeapYear` method may be considered "cheats" for the exercise,
  but `IsLeapYear` would be the idiomatic way to check if a year is a leap year in C#.

For more information, check the [Performance article][article-performance].

[remainder-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[approach-boolean-chain]: https://exercism.org/tracks/csharp/exercises/leap/approaches/boolean-chain
[approach-ternary-operator]: https://exercism.org/tracks/csharp/exercises/leap/approaches/ternary-operator
[approach-switch-on-a-tuple]: https://exercism.org/tracks/csharp/exercises/leap/approaches/switch-on-a-tuple
[approach-datetime-add]: https://exercism.org/tracks/csharp/exercises/leap/approaches/datetime-addition
[approach-datetime-isleapyear]: https://exercism.org/tracks/csharp/exercises/leap/approaches/built-in-method
[article-performance]: https://exercism.org/tracks/csharp/exercises/leap/articles/performance
