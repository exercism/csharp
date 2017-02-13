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

    public static List<TOut> Map<TIn, TOut>(Func<TIn, TOut> map, List<TIn> input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static List<T> Filter<T>(Func<T, bool> predicate, List<T> input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static TOut Foldl<TIn, TOut>(Func<TOut, TIn, TOut> func, TOut start, List<TIn> input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static TOut Foldr<TIn, TOut>(Func<TIn, TOut, TOut> func, TOut start, List<TIn> input)
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