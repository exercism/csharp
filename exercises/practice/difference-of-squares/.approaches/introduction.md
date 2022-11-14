# Introduction

The key to this exercise is to iterate over a list of numbers and apply a transformation to them.

## General guidance

- Don't copy/paste the logic for calculating the square of the sum and the sum of squares to calculate the difference between them; re-use the existing methods.
- Consider introducing a helper method for calculating the square of a number, which could be defined as an [extension method][extension-methods].

## Approach: LINQ

```csharp
public static int CalculateSquareOfSum(int max) =>
    Square(Enumerable.Range(1, max).Sum());

public static int CalculateSumOfSquares(int max) =>
    Enumerable.Range(1, max).Sum(Square);

public static int CalculateDifferenceOfSquares(int max) =>
    CalculateSquareOfSum(max) - CalculateSumOfSquares(max);

private static int Square(int number) => number * number;
```

This approach uses [LINQ][linq] to iterate and map the numbers.
For more information, check the [LINQ approach][approach-linq].

## Which approach to use?

TODO

[approach-linq]: https://exercism.org/tracks/csharp/exercises/difference-of-squares/approaches/linq
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[extension-methods]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
