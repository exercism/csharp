# `AsParallel`

```csharp
using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        return texts.AsParallel().Aggregate(new Dictionary<char, int>(), AddCount);
    }

    private static Dictionary<char, int> AddCount(Dictionary<char, int> letterCounts, string text)
    {
        foreach (var letterCount in text.ToLower().Where(char.IsLetter).GroupBy(c => c))
        {
            if (letterCounts.TryGetValue(letterCount.Key, out var count))
                letterCounts[letterCount.Key] = letterCount.Count() + count;
            else
                letterCounts[letterCount.Key] = letterCount.Count();
        }

        return letterCounts;
    }
}
```

The key to this approach is to use the [`AsParallel()` method][as-parallel], which enables parallel LINQ query execution via [PLINQ][plinq].
We thus start our solution with calling `AsParallel()` on the `IEnumerable<string>` representing the texts:

```csharp
texts.AsParallel()
```

This will return a [`ParallelEnumerable` instance][parallel-enumerable], which has a lot of methods that look like regular LINQ methods, but are subtly different due to them being executed in parallel.

Having enable parallel processing of each text, we then need to count the letters in that text and then combine all those text counts in the end to end up with the global letter count (with all letters lowercased).
The method that is intended for exactly this purpose is the [`Aggregate()` method][parallel-enumerable-aggregate].
We'll use the overload that takes an accumulator value (which is a `Dictionary<char, int>` representing the total letter count) and a function that takes the accumulator value and a single text, and returns a new, updated accumulator value:

```csharp
texts.AsParallel().Aggregate(new Dictionary<char, int>(), AddCount)
```

Let's move on to the `AddCount()` method, which signature looks like this:

```csharp
private static Dictionary<char, int> AddCount(Dictionary<char, int> letterCounts, string text)
```

Let's start by counting each letter, and worry about updating the accumulator after that:

```csharp
text.ToLower().Where(char.IsLetter).GroupBy(c => c)
```

What this code does is it first converts the text to lowercase, then only keeps letter characters after which we group each letter by its own value.
This will return an [`IGrouping<char, char>`][igrouping] instance, that we then iterate over:

```csharp
foreach (var letterCount in text.ToLower().Where(char.IsLetter).GroupBy(c => c))
```

We can get the letter we group on via `letterCount.Key` and the count via `letterCount.Count()`.
The next step is to update the accumulator value, taking into account the fact that the accumulator might already have a count for the letter we're processing.

```csharp
if (letterCounts.TryGetValue(letterCount.Key, out var count))
    letterCounts[letterCount.Key] = letterCount.Count() + count;
else
    letterCounts[letterCount.Key] = letterCount.Count();
```

We use `TryGetValue()` to check if there already is an existing count associated with the key, and if so, we increment the existing value, otherwise we'll assign a new value.

```exercism/note
You don't have to worry about any concurrent updates to the dictionary, PLINQ will handle this for you.
```

Finally, we'll return the updated accumulator value:

```csharp
return letterCounts;
```

## Shortening

When the body of a function is a single expression, the function can be implemented as an [expression-bodied member][expression-bodied-member], like so

```csharp
public static Dictionary<char, int> Calculate(IEnumerable<string> texts) =>
    texts.AsParallel().Aggregate(new Dictionary<char, int>(), AddCount);
```

[plinq]: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/introduction-to-plinq
[as-parallel]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.asparallel
[expression-bodied-member]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
[parallel-enumerable]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable
[parallel-enumerable-aggregate]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.aggregate#system-linq-parallelenumerable-aggregate-2(system-linq-parallelquery((-0))-1-system-func((-1-0-1)))
[igrouping]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.igrouping-2
