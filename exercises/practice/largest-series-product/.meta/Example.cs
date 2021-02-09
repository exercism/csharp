using System;
using System.Collections.Generic;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) => GetSlices(ParseDigits(digits), span).Max(l => GetProduct(l));

    private static IEnumerable<IEnumerable<long>> GetSlices(long[] digits, int span)
    {
        if (span < 0 || span > digits.Length)
        {
            throw new ArgumentException("Invalid span.");
        }

        return Enumerable.Range(0, GetNumberOfSlices(digits, span)).Select(i => digits.Skip(i).Take(span));
    }

    private static long[] ParseDigits(string digits) => digits.ToCharArray().Select(ParseDigit).ToArray();

    private static long ParseDigit(char c)
    {
        if (!char.IsDigit(c))
        {
            throw new ArgumentException("Invalid digit.");
        }

        return long.Parse(c.ToString());
    }

    private static long GetProduct(IEnumerable<long> numbers) => numbers.Aggregate(1L, (x, product) => x * product);

    private static int GetNumberOfSlices(long[] digits, int span) => digits.Length + 1 - span;
}