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

## Approach: `for` statement

```csharp
public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var sum = 0;

        for (var i = 1; i <= max; i++)
            sum += i;

        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        var sumOfSquares = 0;

        for (var i = 1; i <= max; i++)
            sumOfSquares += i * i;

        return sumOfSquares;
    }

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}
```

This approach uses a [`for` statement][for-statement] to manually iterate and map the numbers.
For more information, check the [`for` statement approach][approach-for-statement].

## Which approach to use?

The LINQ-based approach will be a bit slower _and_ allocate more memory, but the difference will not be that big for smaller numbers.
The `for` statement is more performant but also more verbose, as well as having to deal with possible off-by-one errors.

[approach-linq]: https://exercism.org/tracks/csharp/exercises/difference-of-squares/approaches/linq
[approach-for-statement]: https://exercism.org/tracks/csharp/exercises/difference-of-squares/approaches/for-statement
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[extension-methods]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[for-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement
