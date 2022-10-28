# `switch` on a `tuple`

```csharp
    public static bool IsLeapYear(int year) {
        switch ((year % 4, year % 100, year % 400))
        {
            case (_, 0, 0):
                return true;
            case (_, 0, _):
                return false;
            case (0, _, _):
                return true;
            default:
                return false;
        }
    }
```

A [tuple][tuple] is made from the conditions for the year being evenly divisible by `4`, `100` and `400`.

The `tuple` is tested in a [switch][switch].
It checks the values of the expressions in the `tuple`, and uses the `_` [discard pattern][discard-pattern] to disregard a value.
The `default` arm of the `switch` returns `false` when none of the previous ams match.

| year | year % 4 | year % 100 | year % 400 == 0 | is leap year |
| ---- | -------- | ---------- | --------------- | ------------ |
| 2020 |        0 |         20 |              20 |         true |
| 2019 |        3 |         19 |              19 |        false |
| 2020 |        0 |          0 |               0 |         true |
| 1900 |        0 |          0 |             300 |        false |

Although some may consider it to be a more "functional" approach, the `switch` on a `tuple` approach is somewhat more verbose than other approaches,
and may also be considered less readable.
 
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
[switch]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement
[discard-pattern]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#discard-pattern
