# Introduction

There are several idiomatic approaches to solve Leap.

## Approach: Chain of Boolean expressions

```csharp
public static bool IsLeapYear(int year) =>
        year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
```

For more information, check the [Boolean chain approach][approach-boolean-chain].

## Approach: Ternary operator of Boolean expressions

```csharp
public static bool IsLeapYear(int year) => year % 100 == 0 ? year % 400 == 0 : year % 4 == 0;
```

For more information, check the [Ternary operator approach][approach-ternary-operator].

## Approach: `switch` on a `tuple`

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

For more information, check the [`switch` on a `tuple` approach][approach-switch-on-a-tuple].

## Other approaches

- Add a day to February 28th for the year and see if the new day is the 29th. For more information, see the [`DateTime.Add` approach][approach-datetime-add].
- Use the built-in method for the year. For more information, see the [`DateTime.IsLeapYear` approach][approach-datetime-isleapyear].


## Which approach to use?

- The chain of boolean expressions is most efficient, as it proceeds from the most likely to least likely conditions.
It has a maximum of three checks.
- The ternary operator has a maximum of only two checks, but it starts from a less likely condition.
- The `switch` on a `tuple` may be considered more "functional", but it is more verbose and may be considered less readable.
- Using DateTime addition or using the built-in `IsLeapYear` method may be considered "cheats" for the exercise,
but `IsLeapYear` would be the idiomatic way to check if a year is a leap year in C#.

[approach-boolean-chain]: https://exercism.org/tracks/csharp/exercises/leap/approaches/boolean-chain
[approach-ternary-operator]: https://exercism.org/tracks/csharp/exercises/leap/approaches/ternary-operator
[approach-switch-on-a-tuple]: https://exercism.org/tracks/csharp/exercises/leap/approaches/switch-on-a-tuple
[approach-datetime-add]: https://exercism.org/tracks/csharp/exercises/leap/approaches/datetime-addition
[approach-datetime-isleapyear]: https://exercism.org/tracks/csharp/exercises/leap/approaches/built-in-method
