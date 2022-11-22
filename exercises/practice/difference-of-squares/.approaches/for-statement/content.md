# `for` statement

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

    public static int CalculateDifferenceOfSquares(int max) =>
        CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}
```

## Method: `CalculateSquareOfSum()`

The square of the sum is defined as: sum all numbers from `1` to the provided `max`, and then square that number.

Let's start by defining a variable to hold the sum:

```csharp
var sum = 0;
```

We can then iterate over the number using a [`for` statement][for-statement] and add each number to the sum:

```csharp
for (var i = 1; i <= max; i++)
    sum += i;
```

The last step is to run the square of the sum:

```csharp
return sum * sum;
```

## Method: `CalculateSumOfSquares()`

The calculate the sum of the squares, we once again start out with creating an enumerable of the numbers from `1` to `max`:

Let's start by defining a variable to hold the sum:

```csharp
var sumOfSquares = 0;
```

We can then iterate over the number using a [`for` statement][for-statement] and add each number's square to the sum:

```csharp
for (var i = 1; i <= max; i++)
    sumOfSquares += i * i;
```

The last step is to run the sum of the squares:

```csharp
return sumOfSquares;
```

## Method: `CalculateDifferenceOfSquares()`

The `CalculateDifferenceOfSquares()` method is nothing more than calling the two methods we just created:

```csharp
public static int CalculateDifferenceOfSquares(int max) =>
    CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
```

[for-statement]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-for-statement
