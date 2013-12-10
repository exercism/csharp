using System;

public class Hamming
{
    public static int Compute (string firstStrand, string secondStrand)
    {
        return new Hamming(firstStrand,secondStrand).Distance();
    }

    private string firstStrand;
    private string secondStrand;

    public Hamming (string firstStrand, string secondStrand)
    {
        this.firstStrand = firstStrand;
        this.secondStrand = secondStrand;
    }

    public int Distance ()
    {
        char[] firstStrandChars = firstStrand.ToCharArray();
        char[] secondStrandChars = secondStrand.ToCharArray();

        int difference = 0;

        for (int i = 0; i < CommonDistance(); i++)
        {
            if (firstStrandChars[i] != secondStrandChars[i]) { difference++; }
        }

        return difference;
    }

    private int CommonDistance ()
    {
        return Math.Min(firstStrand.Length,secondStrand.Length);
    }
}