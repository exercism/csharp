## `Math.Pow`

```csharp
using System;

public static class Grains
{
    public static double Square(int i)
    {
        if (i is <= 0 or > 64)
            throw new ArgumentOutOfRangeException(nameof(i));

        return Math.Pow(2, i - 1);
    }

    public static double Total()
    {
        return Enumerable.Range(1, 64).Sum(Square);
    }
}
```

Other languages may have an exponential operator such as `**` or `^` to raise a number by a specified power.
C# does not have an exponential operator, but uses the [Math.Pow][pow] method.

`Pow` is nicely suited to the problem, since we start with one grain and keep doubling the number of grains on each successive square.
`1` grain is `Math.Pow(2, 0)`, `2` grains is `Math.Pow(2, 1)`, `4` is `Math.Pow(2, 2)`, and so on.
So, to get the right exponent, we subtract `1` from the square number `i`.

For `Total` we can reuse `Square` by passing it `1` through `64` and summing the result from each call.
This example uses [Enumerable.Range][enumerable-range] to iterate from `1` through `64` and chains it to the [Sum][sum] method.

## Shortening

When the body of an `if` statement is a single line, both the test expression and the body could be put on the same line, like so

```csharp
if (i is <= 0 or > 64) throw new ArgumentOutOfRangeException(nameof(i));
```

The [C# Coding Conventions][coding-conventions] advise to write only one statement per line in the [layout conventions][layout-conventions] section,
but the conventions begin by saying you can use them or adapt them to your needs.
Your team may choose to overrule them.

When the body of a function is a single expression, the function can be implemented as a [expression-bodied member][expression-bodied-member], like so

```csharp
public static double Total() =>
    Enumerable.Range(1, 64).Sum(Square);
```

or

```csharp
public static double Total() => Enumerable.Range(1, 64).Sum(Square);
```

[pow]: https://learn.microsoft.com/en-us/dotnet/api/system.math.pow
[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range
[sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum
[coding-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
[layout-conventions]: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#layout-conventions
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
