using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}