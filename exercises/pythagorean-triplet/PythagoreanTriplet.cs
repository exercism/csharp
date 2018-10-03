using System;
using System.Collections.Generic;

public class Triplet
{
    private readonly int a;
    private readonly int b;
    private readonly int c;
    
    public Triplet(int a, int b, int c)
    {
    }

    public int Sum()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public int Product()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public bool IsPythagorean()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static IEnumerable<Triplet> Where(int maxFactor, int minFactor = 1, int sum = 0)
    {
        throw new NotImplementedException("You need to implement this function.");
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
}