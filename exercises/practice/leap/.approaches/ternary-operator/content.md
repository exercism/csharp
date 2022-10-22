# Ternary operator

```csharp
public static bool IsLeapYear(int year) => year % 100 == 0 ? year % 400 == 0 : year % 4 == 0;
```

A [conditional operator][ternary-operator], also known as a "ternary conditional operator", or just "ternary operator",
uses a maximum of two checks to determine if a year is a leap year.

It starts by testing the outlier condition of the year being evenly divisible by `100`.
It does this by using the [remainder operator][remainder-operator].
If the year is evenly divisible by `100`, then the expression is `true`, and the ternary operator returns if the year is evenly divisible by `400`.
If the year is _not_ evenly divisible by `100`, then the expression is `false`, and the ternary operator returns if the year is evenly divisible by `4`.

Although it uses a maximum of only two checks, the ternary operator tests an outlier condition first,
making it less efficient than another approach that would first test if the year is evenly divisible by `4`,
which is more likely than the year being evenly divisible by `100`.

Since the ternary operator is one expression, the function can be implemented as an [expression-bodied member][expression-bodied-member].

[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[remainder-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
