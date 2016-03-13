using System;
using System.Collections.Generic;
using System.Linq;

public class LargestSeriesProduct
{
    private readonly string digits;

    private int[] Digits;

    public LargestSeriesProduct(string digits)
    {
        this.digits = digits;
        Digits = ParseValues(digits);
    }

    private int[] ParseValues(IEnumerable<char> values)
    {
        return values.Select(x => int.Parse(x.ToString())).ToArray();
    }

    private int[][] GetSlices(int limit)
    {
        if (limit > digits.Length) throw new ArgumentException("Slice size is too big");
        var slices = new List<int[]>();
        for (int i = 0; i <= digits.Length - limit; i++)
        {
            slices.Add(ParseValues(digits.Skip(i).Take(limit)));
        }
        return slices.ToArray();
    }

    public int GetLargestProduct(int seriesLength)
    {
        if (seriesLength < 1) return 1;
        return GetSlices(seriesLength).Aggregate(0, (prev, next) =>
            {
                int product = next.Aggregate((x, y) => x * y);
                return product > prev ? product : prev;
            });
    }
}