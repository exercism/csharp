using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length == 0 || sliceLength <= 0 || sliceLength > numbers.Length)
            throw new ArgumentException();

        return Enumerable.Range(0, numbers.Length - sliceLength + 1)
            .Select(i => numbers.Substring(i, sliceLength))
            .ToArray();
    }
}