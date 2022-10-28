# Chain of boolean expressions

```csharp
public static bool IsLeapYear(int year)
{
    return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
}
```

The first boolean expression uses the [remainder operator][remainder-operator] to check if the year is evenly divided by `4`.
- If the year is not evenly divisible by `4`, then the chain will "short circuit" due to the next operator being a [logical AND][logical-and] (`&&`), and will return `false`.
- If the year _is_ evenly divisible by `4`, then the year is checked to _not_ be evenly divisible by `100`.
- If the year is not evenly divisible by `100`, then the expression is `true` and the chain will "short-circuit" to return `true`,
since the next operator is a [logical OR][logical-or] (`||`).
- If the year _is_ evenly divisible by `100`, then the expression is `false`, and the returned value from the chain will be if the year is evenly divisible by `400`.

| year | year % 4 == 0 | year % 100 != 0 | year % 400 == 0 | is leap year |
| ---- | ------------- | --------------- | --------------- | ------------ |
| 2020 |          true |            true |   not evaluated |         true |
| 2019 |         false |   not evaluated |   not evaluated |        false |
| 2000 |          true |           false |            true |         true |
| 1900 |          true |           false |           false |        false |


The chain of boolean expressions is efficient, as it proceeds from testing the most likely to least likely conditions.

## Shortening

When the body of a function is a single expression, the function can be implemented as an [expression-bodied member][expression-bodied-member], like so

```csharp
public static bool IsLeapYear(int year) =>
    year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
```

or

```csharp
public static bool IsLeapYear(int year) => year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
```

[remainder-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-
[logical-and]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#conditional-logical-and-operator-
[logical-or]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators#conditional-logical-or-operator-
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
