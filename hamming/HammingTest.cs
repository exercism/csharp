using NUnit.Framework;

[TestFixture]
public class HammingTest
{
    [Test]
    public void NoDifferenceBetweenEmptyStrands ()
    {
        Assert.AreEqual(0,Hamming.Compute("",""));
    }

    [Test, Ignore]
    public void NoDifferenceBetweenIdenticalStrands ()
    {
        Assert.AreEqual(0,Hamming.Compute("GGACTGA","GGACTGA"));
    }

    [Test, Ignore]
    public void CompleteHammingDistanceInSmallStrand ()
    {
        Assert.AreEqual(3,Hamming.Compute("ACT","GGA"));
    }

    [Test, Ignore]
    public void HammingDistanceInOffByOneStrand ()
    {
        Assert.AreEqual(9,Hamming.Compute("GGACGGATTCTG","AGGACGGATTCT"));
    }

    [Test, Ignore]
    public void SmallingHammingDistanceInMiddleSomewhere ()
    {
        Assert.AreEqual(1,Hamming.Compute("GGACG","GGTCG"));
    }

    [Test, Ignore]
    public void LargerDistance ()
    {
        Assert.AreEqual(2,Hamming.Compute("ACCAGGG","ACTATGG"));
    }

    [Test, Ignore]
    public void IgnoresExtraLengthOnOtherStrandWhenLonger ()
    {
        Assert.AreEqual(3,Hamming.Compute("AAACTAGGGG","AGGCTAGCGGTAGGAC"));
    }

    [Test, Ignore]
    public void IgnoresExtraLengthOnOriginalStrandWhenLonger ()
    {
        Assert.AreEqual(5,Hamming.Compute("GACTACGGACAGGGTAGGGAAT","GACATCGCACACC"));
    }
}