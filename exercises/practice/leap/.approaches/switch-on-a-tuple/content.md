# `switch` on a `tuple`

```csharp
public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        return (year % 4, year % 100, year % 400) switch
        {
            (_, _, 0) => true,
            (_, 0, _) => false,
            (0, _, _) => true,
            _ => false,
        };
    }
}
```

A [tuple][tuple] is made from the conditions for the year being evenly divisible by `4`, `100` and `400`.

The `tuple` is tested in a [switch expression][switch-expression].
It checks the values of the expressions in the `tuple`, and uses the `_` [discard pattern][discard-pattern] to disregard a value.
The `default` arm of the `switch` returns `false` when none of the previous arms match.

| year | year % 4 | year % 100 |   year % 400    | is leap year |
| ---- | -------- | ---------- | --------------- | ------------ |
| 2020 |        0 |         20 |              20 |         true |
| 2019 |        3 |         19 |              19 |        false |
| 2000 |        0 |          0 |               0 |         true |
| 1900 |        0 |          0 |             300 |        false |

Although some may consider it to be a more "functional" approach, the `switch` on a `tuple` approach is somewhat more verbose than other approaches,
and may also be considered less readable.
 
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[switch-expression]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
[discard-pattern]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#discard-pattern
