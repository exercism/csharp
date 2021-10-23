# Hints

## General

- [Floating-point numeric types introduction][docs.microsoft.com-floating_point_numeric_types].

## 1. Calculate the interest rate

- By default, any floating-point number defined in C# code is treated as a `double`. To use a different floating-point type (like `float` or `decimal`), one must add the appropriate [suffix][docs.microsoft.com-real_literals] to the number.

## 2. Calculate the interest

- When calculating interest, it might be helpful to notice that `InterestRate` returns a percentage.

## 3. Calculate the annual balance update

- When calculating the annual balance update, we can use methods we have defined in previous steps.

## 4. Calculate the years before reaching the desired balance

- To calculate the years, one can keep looping until the desired balance is reached. C# has several [looping constructs][docs.microsoft.com-loops].
- There is a special [operator][increment-operator] to increment values by 1.

[docs-microsoft.com-system.math]: https://docs.microsoft.com/en-us/dotnet/api/system.math?view=netcore-3.0
[docs.microsoft.com-floating_point_numeric_types]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
[docs.microsoft.com-real_literals]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types#real-literals
[docs.microsoft.com-loops]: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/intro-to-csharp/branches-and-loops-local#use-loops-to-repeat-operations
[increment-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#increment-operator-
