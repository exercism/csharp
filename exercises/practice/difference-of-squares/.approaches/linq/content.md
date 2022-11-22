# LINQ

```csharp
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) =>
        Square(Enumerable.Range(1, max).Sum());

    public static int CalculateSumOfSquares(int max) =>
        Enumerable.Range(1, max).Sum(Square);

    public static int CalculateDifferenceOfSquares(int max) =>
        CalculateSquareOfSum(max) - CalculateSumOfSquares(max);

    private static int Square(int number) => number * number;
}
```

Before we start, let's define a helper method to square a number:

```csharp
private static int Square(int number) => number * number;
```

Having this method will allow us to write more concise code later on.

## Method: `CalculateSquareOfSum()`

The square of the sum is defined as: sum all numbers from `1` to the provided `max`, and then square that number.

We can get an enumerable for all the numbers using [LINQ][linq]'s [`Enumerable.Range()` method][enumerable-range]:

```csharp
Enumerable.Range(1, max)
```

Summing these numbers is a simple matter of calling the [`Sum()` method][enumerable-sum] on the enumerable:

```csharp
Enumerable.Range(1, max).Sum()
```

Finally, we can pass this sum to our `Square()` helper method to calculate the correct value.

```csharp
public static int CalculateSquareOfSum(int max) =>
    Square(Enumerable.Range(1, max).Sum());
```

## Method: `CalculateSumOfSquares()`

The calculate the sum of the squares, we once again start out with creating an enumerable of the numbers from `1` to `max`:

```csharp
Enumerable.Range(1, max).Sum()
```

We then need to square these numbers, which we can do using the [`Select()` method][enumerable-select]:

```csharp
Enumerable.Range(1, max).Select(n => Square(n))
```

We can then call `Sum()` to return the correct value:

```csharp
public static int CalculateSumOfSquares(int max) =>
    Enumerable.Range(1, max).Select(n => Square(n)).Sum();
```

### Shortening

There are two things we can do to shorten this method.
The first is that instead of doing `Select()` and then `Sum()`, we can use the overload of the `Sum()` method that takes a lambda (this will have the exact same effect):

```csharp
public static int CalculateSumOfSquares(int max) =>
    Enumerable.Range(1, max).Sum(n => Square(n));
```

And finally, as the lambda used in the `Select()` method just passes the argument to a function, we can use a [method group][method-group] to shorten this to:

```csharp
public static int CalculateSumOfSquares(int max) =>
    Enumerable.Range(1, max).Sum(Square);
```

## Method: `CalculateDifferenceOfSquares()`

The `CalculateDifferenceOfSquares()` method is nothing more than calling the two methods we just created:

```csharp
public static int CalculateDifferenceOfSquares(int max) =>
    CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
```

[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range
[enumerable-sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum
[enumerable-select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[method-group]: https://stackoverflow.com/questions/35420610/passing-a-method-to-a-linq-query
