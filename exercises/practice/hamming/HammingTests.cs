using Xunit;

public class HammingTests
{
    [Fact]
    public void EmptyStrands()
    {
        Assert.Equal(0, Hamming.Distance("", ""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SingleLetterIdenticalStrands()
    {
        Assert.Equal(0, Hamming.Distance("A", "A"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SingleLetterDifferentStrands()
    {
        Assert.Equal(1, Hamming.Distance("G", "T"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LongIdenticalStrands()
    {
        Assert.Equal(0, Hamming.Distance("GGACTGAAATCTG", "GGACTGAAATCTG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LongDifferentStrands()
    {
        Assert.Equal(9, Hamming.Distance("GGACGGATTCTG", "AGGACGGATTCT"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DisallowFirstStrandLonger()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("AATG", "AAA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DisallowSecondStrandLonger()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("ATA", "AGTG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DisallowEmptyFirstStrand()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("", "G"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DisallowEmptySecondStrand()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("G", ""));
    }
}
