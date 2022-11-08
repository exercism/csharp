# `if` statement

```csharp
using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException(nameof(number));

        var sumOfFactors = Enumerable.Range(1, number / 2)
            .Where(factor => number % factor == 0)
            .Sum();

        if (sumOfFactors < number)
            return Classification.Deficient;

        if (sumOfFactors > number)
            return Classification.Abundant;

        return Classification.Perfect;
    }
}
```

The first step is to check the `number` for validity:

```csharp
if (number < 1)
    throw new ArgumentOutOfRangeException(nameof(number));
```

The next step is to calculate the sum of the number's factors.
A factor is a number that you can divide another number with and not end up with a remainder, which we can check using the modulo (`%%`) operator: `number % factor == 0`.

We then need to decide which numbers could possibly be factors.
For the lower bound, we can use `1`, as that is always the smallest factor.
For the upper bound, we can leverage the fact that the second lowest factor is `2`, which means that any numbers greater than `number / 2` cannot be factors.

We can use the [`Enumerable.Range() method][enumerable-range] to iterate over the possible factors, then use [`Where()`][enumerable-where] to select only valid factors and then finally sum them via the [`Sum() method`][enumerable-sum]:

```csharp
var sumOfFactors = Enumerable.Range(1, number / 2)
    .Where(factor => number % factor == 0)
    .Sum();
```

Then finally we can apply the logic to classify the perfect number via some `if` statements:

```csharp
if (sumOfFactors < number)
    return Classification.Deficient;

if (sumOfFactors > number)
    return Classification.Abundant;

return Classification.Perfect;
```

## Shortening

You could use the [ternary operator][ternary-operator] to replace the `if` statements:

```csharp
return sumOfFactors < number ? Classification.Deficient :
       sumOfFactors > number ? Classification.Abundant :
       Classification.Perfect;
```

[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range
[enumerable-where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[enumerable-sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum
