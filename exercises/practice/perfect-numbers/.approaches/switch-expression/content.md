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

This approach does the following:
1. Takes a _range_ of numbers starting from the number `1` up until (but not including) the number being classified.
2. For each number, it keeps the number if it is a factor, otherwise replaces it with a zero.
3. Sums all the numbers and classifies this sum according to given instructions.

Let's go through this in more detail:

In the first step a range of numbers is generated using the [Range() function][enumerable-range], giving it a starting number (`1`) and a _count_ of how many numbers we want.

```csharp
Enumerable.Range(1, number - 1)
```

You can test whether a number is a factor by using the modulo (`%`) operator and checking whether there's no remainder.
The line `.Sum(n => number % n == 0 ? n : 0);` keeps every factor and uses a `0` in place of every number that _isn't_ a factor and then using [sum][enumerable-sum] to sum these.

Finally, we need to _classify_ the number, this is done using [switch expression][switch-expression] on a [tuple][tuple] with the two necessary checks (the third `Perfect` case being implicitly tested):

```csharp
return (sum < number, sum > number) switch
{
    (true, _) => Classification.Deficient,
    (_, true) => Classification.Abundant,
    _ => Classification.Perfect,
};
```

## Range and upperbound considerations

We're using a property of the [Range() function][enumerable-range] that it returns an empty range when giving it a _zero_ count; we can use other functions on an empty range (like [sum][enumerable-sum] in this case) without any problem.
This means that we _do not_ first have to verify whether `number` is positive.
The downside of using [range][enumerable-range] this way is that we ask for more numbers than we need (`number - 1`); if we wouldn't have to take into account `0`, we could divide any given number by `2` (since a factor of a number can only be - at most - half the number) and use that as the upperbound (`count`).

## Sum vs. Where and Sum
The line `.Sum(n => number % n == 0 ? n : 0);` can also be written as `.Where(n => number % n == 0).Sum();`, using [where][enumerable-where] to _keep_ only the factors and then [sum][enumerable-sum] the result, but this is a little more verbose.

[enumerable-range]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.range
[enumerable-where]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where
[enumerable-sum]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum
[switch-expression]: https://learn.microsoft.com/en-US/dotnet/csharp/language-reference/operators/switch-expression
[tuple]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
