using System;
using System.Linq;

public class Hamming
{
    public static int Compute(string firstStrand, string secondStrand)
    {
        return new Hamming(firstStrand,secondStrand).Distance();
    }

    private readonly string firstStrand;
    private readonly string secondStrand;

    public Hamming(string firstStrand, string secondStrand)
    {
        this.firstStrand = firstStrand;
        this.secondStrand = secondStrand;
        ValidateStrands();
    }

    private void ValidateStrands()
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("Undefined for sequences of unequal length");
    }

    public int Distance()
    {
        return firstStrand.Where((x, i) => x != secondStrand[i]).Count();
    }
}