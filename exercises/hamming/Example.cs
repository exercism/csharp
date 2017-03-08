using System;
using System.Linq;

public static class Hamming
{
    public static int Compute(string firstStrand, string secondStrand)
    {
        return firstStrand.Where((x, i) => x != secondStrand[i]).Count();
    }
}