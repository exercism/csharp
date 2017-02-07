using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static IEnumerable<Tuple<int, int>> Chain(IEnumerable<Tuple<int, int>> dominoes)
    {
        if (!dominoes.Any())
            return Enumerable.Empty<Tuple<int, int>>();
        
        return AllPaths(dominoes).Where(IsValidPath).FirstOrDefault();
    }

    public static IEnumerable<IEnumerable<Tuple<int, int>>> AllPaths(IEnumerable<Tuple<int, int>> dominoes)
    {
        var first = dominoes.First();

        var unmodifiedFirst = new[] { first };
        var swappedFirst    = new[] { first.Swap() };

        if (dominoes.Count() == 1)
            return new[] { unmodifiedFirst, swappedFirst };

        var remainingPaths = AllPaths(dominoes.Skip(1));
        var unmodifiedPaths = remainingPaths.SelectMany(path => unmodifiedFirst.Concat(path).Rotations());
        var swappedPaths = remainingPaths.SelectMany(path => swappedFirst.Concat(path).Rotations());

        return unmodifiedPaths.Concat(swappedPaths);
    }

    private static IEnumerable<IEnumerable<T>> Rotations<T>(this IEnumerable<T> input)
        =>  Enumerable.Range(0, input.Count()).Select(i => input.Rotate(i));

    private static IEnumerable<T> Rotate<T>(this IEnumerable<T> input, int n)
        => input.Skip(n).Take(input.Count() - n).Concat(input.Take(n));

    private static Tuple<T2, T1> Swap<T1, T2>(this Tuple<T1, T2> input)
        => new Tuple<T2, T1>(input.Item2, input.Item1);
    
    private static bool IsValidPath(IEnumerable<Tuple<int, int>> chain)
    {
        if (!chain.Any())
            return true;

        var first = chain.First();

        if (chain.Count() == 1)
            return first.Item1 == first.Item2;

        var second = chain.Skip(1).First();

        if (first.Item2 != second.Item1)
            return false;

        return IsValidPath(new[] { Tuple.Create(first.Item1, second.Item2) }.Concat(chain.Skip(2)));
    }
}