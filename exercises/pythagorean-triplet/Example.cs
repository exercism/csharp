using System;
using System.Collections.Generic;

public class Triplet
{
    private readonly int a;
    private readonly int b;
    private readonly int c;

    public Triplet(int a, int b, int c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public int Sum()
    {
        return a + b + c;
    }

    public int Product()
    {
        return a * b * c;
    }

    public bool IsPythagorean()
    {
        return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
    }

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {
        var triplets = new List<Triplet>();
        for (int i = minFactor; i < maxFactor - 1; i++)
        {
            for (int j = i + 1; j < maxFactor; j++)
            {
                for (int k = j + 1; k <= maxFactor; k++)
                {
                    var triplet = new Triplet(i, j, k);
                    if (ShouldIncludeTriplet(sum, triplet))
                        triplets.Add(triplet);
                }
            }
        }
        return triplets;
    }

    private static bool ShouldIncludeTriplet(int sum, Triplet triplet)
    {
        return triplet.IsPythagorean() && (sum == 0 || triplet.Sum() == sum);
    }
}