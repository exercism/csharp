using System;
using System.Collections;
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
        return Foldl(input, 0, (acc, x) => acc + 1);
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        return Foldl(input, new List<T>(), (acc, x) => Cons(x, acc));
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        return Foldr(input, new List<TOut>(), (x, acc) => Cons(map(x), acc));
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        return Foldr(input, new List<T>(), (x, acc) => predicate(x) ? Cons(x, acc) : acc);
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        var acc = start;

        foreach (var item in input)
            acc = func(acc, item);

        return acc;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
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
        {
            if (list is List<T> sublist)
                concatenated = Append(concatenated, sublist);
        }
            

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