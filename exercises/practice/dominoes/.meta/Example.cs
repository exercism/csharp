using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        if (!dominoes.Any())
        {
            return true;
        }

        var domino = dominoes.First();

        if (dominoes.Count() == 1)
        {
            return domino.Item1 == domino.Item2;
        }

        return dominoes.Skip(1).Rotate().Any(sublist => PossibleChains(domino, sublist).Any(CanChain));
    }

    public static IEnumerable<(int, int)[]> PossibleChains((int, int) domino, IEnumerable<(int, int)> remainder)
    {
        var head = remainder.First();

        if (domino.Item2 == head.Item1)
        {
            yield return new[] { (domino.Item1, head.Item2) }.Concat(remainder.Skip(1)).ToArray();
        }
        else if (domino.Item2 == head.Item2)
        {
            yield return new[] { (domino.Item1, head.Item1) }.Concat(remainder.Skip(1)).ToArray();
        }
    }

    private static IEnumerable<IEnumerable<T>> Rotate<T>(this IEnumerable<T> input)
    {
        return Enumerable.Range(0, input.Count()).Select(i => input.Skip(i).Take(input.Count() - i).Concat(input.Take(i)));
    }
}