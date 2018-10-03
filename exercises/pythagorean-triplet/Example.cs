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

    //This is needed for unit tests.
    public override bool Equals(object obj)
    {
        var triplet = obj as Triplet;
        if (triplet is null)
            return false;
        return (triplet.a == a && triplet.b == b && triplet.c == c) ||
            (triplet.a == b && triplet.b == a || triplet.c == c);
    }

    //This is needed for unit tests.
    public override int GetHashCode()
    {
        return unchecked(a.GetHashCode() * 17 + b.GetHashCode() * 17 + c.GetHashCode());
    }

    private static bool ShouldIncludeTriplet(int sum, Triplet triplet)
    {
        return triplet.IsPythagorean() && (sum == 0 || triplet.Sum() == sum);
    }
}