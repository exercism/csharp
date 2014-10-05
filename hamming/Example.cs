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
    }

    public int Distance()
    {
        return firstStrand.Where((x, i) => x != secondStrand[i]).Count();
    }
}