# `switch` expression

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        var sum = Enumerable.Range(1, number - 1)
            .Sum(n => number % n == 0 ? n : 0);
            
        return (sum < number, sum > number) switch
        {
            (true, _) => Classification.Deficient,
            (_, true) => Classification.Abundant,
            _ => Classification.Perfect,
        };
    }
}
```

This approach (in short):
1. Takes a _range_ of numbers starting from the number `1` up until (but not including) the number being classified.
2. Keeping only the numbers which are a _factor_ of the number being classified.
3. Summing these factors and classifying this sum according to given instructions.

Let's go through this in more detail:

In the first step a range of numbers is generated using the [Range() function][enumerable-range], giving it a starting number (`1`) and a _count_ of how many numbers we want. We're using a property of the [Range() function][enumerable-range] that it just returns an empty list when giving it a non-positive count instead of this causing an error; we can use other functions a empty list (like [sum][enumerable-sum] in this case) without any problem. The downside of this is that the range is longer than necessary in most cases, if we wouldn't have to take into account the number `0`, we could divide the given number by `2` since a factor of a number can only - at most - be _half_ the number.

```csharp
Enumerable.Range(1, number - 1)
```

You can test whether a number is a factor of another number by using the modulo (`%`) operator and checking whether there's no remainder. The line: `.Sum(n => number % n == 0 ? n : 0);` keeps every factor and a `0` for every number that _isn't_ a factor and then using [sum][enumerable-sum] to sum these. This could also be written as `.Where(n => number % n == 0).Sum();`, using [where][enumerable-where] to _keep_ only the factors, but this is a little more verbose.

Finally, we need to _classify_ the number, this is done using [switch expression][switch-expression] on a [tuple][tuple] with the two necessary checks (the third `Perfect` case being implicitly tested):

```csharp
return (sum < number, sum > number) switch
{
    (true, _) => Classification.Deficient,
    (_, true) => Classification.Abundant,
    _ => Classification.Perfect,
};
```

[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range
[enumerable-where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[enumerable-sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum
[switch-expression]: https://learn.microsoft.com/en-US/dotnet/csharp/language-reference/operators/switch-expression
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
