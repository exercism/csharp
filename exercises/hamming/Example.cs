using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("strand lengths must be equal");
        }

        return firstStrand.Where((x, i) => x != secondStrand[i]).Count();
    }
}