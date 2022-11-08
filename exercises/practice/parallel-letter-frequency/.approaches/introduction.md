# Introduction

The key to this exercise is to run the character counting code in parallel.

## General guidance

- The "default" data structures are not safe to be updated concurrently; there are special concurrent data structures that you can use for this

## Approach: `AsParallel()`

```csharp
public static Dictionary<char, int> Calculate(IEnumerable<string> texts) =>
    texts.AsParallel().Aggregate(new Dictionary<char, int>(), AddCount);

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
```

This approach uses the [`AsParallel()` method][as-parallel] to parallelize a LINQ query.
For more information, check the [`AsParallel()` approach][approach-as-parallel].

[approach-as-parallel]: https://exercism.org/tracks/csharp/exercises/gigasecond/approaches/as-parallel
[as-parallel]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.parallelenumerable.asparallel
