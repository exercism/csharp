using System;
using System.Collections.Generic;
using System.Linq;

public class Series
{
    private readonly string numbers;

    public Series(string numbers)
    {
        this.numbers = numbers;
    }

    public int[][] Slices(int sliceLength)
    {
        if (sliceLength > numbers.Length)
            throw new ArgumentException("Slice length can't be longer than the given number");

        var result = new List<int[]>();

        for (int i = 0; SliceEndIndex(sliceLength, i) < numbers.Length; i++)
            result.Add(SplitIntoInts(numbers.Substring(i, sliceLength)));

        return result.ToArray();
    }

    private static int SliceEndIndex(int sliceLength, int idx)
    {
        return idx + sliceLength - 1;
    }

    private static int[] SplitIntoInts(string value)
    {
        return value.Select(x => int.Parse(x.ToString())).ToArray();
    }
}