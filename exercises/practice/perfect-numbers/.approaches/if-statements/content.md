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

        var sum = Enumerable.Range(1, number / 2)
            .Sum(n => number % n == 0 ? n : 0);

        if (sum < number)
            return Classification.Deficient;

        if (sum > number)
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
A factor is a number that you can divide another number with and not end up with a remainder, which we can check using the modulo (`%`) operator: `number % factor == 0`.

We then need to decide which numbers could possibly be factors.
For the lower bound, we can use `1`, as that is always the smallest factor.
For the upper bound, we can leverage the fact that the second lowest factor is `2`, which means that any numbers greater than `number / 2` cannot be factors.

We can use the [Enumerable.Sum() method][enumerable-sum] to sum all the factors, but since not all numbers are factors we need to deal with the numbers that aren't.
We provide the [Enumerable.Sum() method][enumerable-sum] with a lambda that tells it to keep every factor and use a `0` in place of every number that isn't, effectively disregarding it when summing.

```csharp
var sum = Enumerable.Range(1, number / 2)
    .Sum(n => number % n == 0 ? n : 0);
```

Then finally we can apply the logic to classify the perfect number via some `if` statements:

```csharp
if (sum < number)
    return Classification.Deficient;

if (sum > number)
    return Classification.Abundant;

return Classification.Perfect;
```

## Sum vs. Where and Sum
The line `.Sum(n => number % n == 0 ? n : 0);` can also be written as `.Where(n => number % n == 0).Sum();`, using [Enumerable.Where() method][enumerable-where] to _keep_ only the factors and then [Enumerable.Sum() method][enumerable-sum] the result, but this is a little more verbose.

## Shortening

You could use the [ternary operator][ternary-operator] to replace the `if` statements:

```csharp
return sum < number ? Classification.Deficient :
       sum > number ? Classification.Abundant :
       Classification.Perfect;
```

[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range
[enumerable-where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[enumerable-sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum
