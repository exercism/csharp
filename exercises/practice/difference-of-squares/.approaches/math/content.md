# Math

```csharp
public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var sum = max * (max + 1) / 2;
        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max) =>
        (max * (max + 1) * ((max * 2) + 1)) / 6;

    public static int CalculateDifferenceOfSquares(int max) =>
        CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}
```

## Method: `CalculateSquareOfSum()`

The square of the sum is defined as: sum all numbers from `1` to the provided `max`, and then square that number.

The formula to calculate the sum of numbers `1` to `max` is: `max * (max + 1) / 2`.
We can directly convert this to code and then return its square:

```csharp
var sum = max * (max + 1) / 2;
return sum * sum;
```

## Method: `CalculateSumOfSquares()`

The calculate the sum of the squares, we can use the following formula: `(max * (max + 1) * ((max * 2) + 1)) / 6`.
As this has the summation and squaring built-in, we can directly return this formula in code:

```csharp
public static int CalculateSumOfSquares(int max) =>
    (max * (max + 1) * ((max * 2) + 1)) / 6;
```

## Method: `CalculateDifferenceOfSquares()`

The `CalculateDifferenceOfSquares()` method is nothing more than calling the two methods we just created:

```csharp
public static int CalculateDifferenceOfSquares(int max) =>
    CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
```
