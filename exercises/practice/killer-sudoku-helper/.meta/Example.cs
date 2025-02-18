using System.Collections.Generic;
using System.Linq;

public static class KillerSudokuHelper
{
    private static readonly int[] Digits = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    public static IEnumerable<int[]> Combinations(int sum, int size, int[] exclude) =>
        Digits.Except(exclude).ToArray()
            .Combinations(size)
            .Where(comb => comb.Sum() == sum);

    private static IEnumerable<T[]> Combinations<T>(this T[] items, int size)
    {
        if (size > items.Length) yield break;

        var pool = items.ToArray();
        var indices = Enumerable.Range(0, size).ToArray();

        yield return indices.Select(x => pool[x]).ToArray();

        while (true)
        {
            var i = indices.Length - 1;
            while (i >= 0 && indices[i] == i + items.Length - size)
                i -= 1;

            if (i < 0) yield break;

            indices[i] += 1;

            for (var j = i + 1; j < size; j += 1)
                indices[j] = indices[j - 1] + 1;

            yield return indices.Select(x => pool[x]).ToArray();
        }
    }
}