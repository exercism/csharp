using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    private static List<T> Cons<T>(T x, List<T> input)
    {
        var list = new List<T>(input);
        list.Insert(0, x);

        return list;
    }

    public static int Length<T>(List<T> input)
    {
        return Foldl((acc, x) => acc + 1, 0, input);
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        return Foldl((acc, x) => Cons(x, acc), new List<T>(), input);
    }

    public static List<TOut> Map<TIn, TOut>(Func<TIn, TOut> map, List<TIn> input)
    {
        return Foldr((x, acc) => Cons(map(x), acc), new List<TOut>(), input);
    }

    public static List<T> Filter<T>(Func<T, bool> predicate, List<T> input)
    {
        return Foldr((x, acc) => predicate(x) ? Cons(x, acc) : acc, new List<T>(), input);
    }

    public static TOut Foldl<TIn, TOut>(Func<TOut, TIn, TOut> func, TOut start, List<TIn> input)
    {
        var acc = start;

        foreach (var item in input)
            acc = func(acc, item);

        return acc;
    }

    public static TOut Foldr<TIn, TOut>(Func<TIn, TOut, TOut> func, TOut start, List<TIn> input)
    {
        var acc = start;

        for (var i = input.Count - 1; i >= 0; i--)
            acc = func(input[i], acc);

        return acc;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var concatenated = new List<T>();

        foreach (var list in input)
            concatenated = Append(concatenated, list);

        return concatenated;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        var appended = new T[left.Count + right.Count];

        for (var i = 0; i < left.Count; i++)
            appended[i] = left[i];

        for (var j = 0; j < right.Count; j++)
            appended[left.Count + j] = right[j];

        return appended.ToList();
    }
}