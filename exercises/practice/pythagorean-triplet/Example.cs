using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{

    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        var triplets = new List<(int a, int b, int c)>();
        for (var c = sum / 2; c > 1; c--)
        {
            var left = sum - c;
            for (int a = 1, b = left - a; b > a; a++, b--)
            {
                if (a * a + b * b == c * c)
                    yield return (a, b, c);
            }
        }
    }

}