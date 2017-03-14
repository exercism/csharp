using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}