using System;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        return ApplyPredicate(collection, predicate);
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        return ApplyPredicate(collection, x => !predicate(x));
    }

    private static IEnumerable<T> ApplyPredicate<T>(IEnumerable<T> collection, Func<T, bool> predicate)
    {
        // could knock this down to a simple LINQ expression but restriction prevents that
        var filtered = new List<T>();
        foreach (var item in collection)
        {
            if (predicate(item))
                filtered.Add(item);
        }
        return filtered;
    }
}