## `Math.Pow`

```csharp
    // uses System.Linq for Enumerable.Range and Sum
    public static double Square(int i)
    {
        if (i is <= 0 or > 64) throw new ArgumentOutOfRangeException(nameof(i));
        
        return Math.Pow(2, i - 1);
    }
    
    public static double Total() => Enumerable.Range(1, 64).Sum(Square);
```

Other languages may have an exponential operator such as `**` or `^` to raise a number by a specified power.
C# does not have an exponential operator, but uses the [Math.Pow][pow] method.

`Pow` is nicely suited to the problem, since we start with one grain and keep doubling the number of grains on each successive square.
`1` grain is `Math.Pow(2, 0)`, `2` grains is `Math.Pow(2, 1)`, `4` is `Math.Pow(2, 2)`, and so on.
So, to get the right exponent, we subtract `1` from the square number `i`.

For `Total` we can reuse `Square` by passing it `1` through `64` and summing the result from each call.
This example uses [Enumerable.Range][enumerable-range] to iterate from `1` through `64` and chains it to the [Sum][sum] method.
Since it is implemented as a single expression, `Total` is constructed as an [expression-bodied member][expression-bodied-member].

[pow]: https://learn.microsoft.com/en-us/dotnet/api/system.math.pow?view=net-7.0
[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range?view=net-7.0
[sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum?view=net-7.0
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
