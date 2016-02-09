using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<T> Accumulate<T>(this IEnumerable<T> collection, Func<T, T> func)
    {
        foreach (var item in collection)
            yield return func(item);
    }
}