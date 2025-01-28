using Xunit;

public class RotationalCipherTests
{
    [Fact]
    public void RotateABy0SameOutputAsInput()
    {
        Assert.Equal(a, RotationalCipher.Rotate("a", 0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateABy1()
    {
        Assert.Equal(b, RotationalCipher.Rotate("a", 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateABy26SameOutputAsInput()
    {
        Assert.Equal(a, RotationalCipher.Rotate("a", 26));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateMBy13()
    {
        Assert.Equal(z, RotationalCipher.Rotate("m", 13));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateNBy13WithWrapAroundAlphabet()
    {
        Assert.Equal(a, RotationalCipher.Rotate("n", 13));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateCapitalLetters()
    {
        Assert.Equal(TRL, RotationalCipher.Rotate("OMG", 5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateSpaces()
    {
        Assert.Equal(T R L, RotationalCipher.Rotate("O M G", 5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateNumbers()
    {
        Assert.Equal(Xiwxmrk 1 2 3 xiwxmrk, RotationalCipher.Rotate("Testing 1 2 3 testing", 4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotatePunctuation()
    {
        Assert.Equal(Gzo 'n zvo, Bmviyhv!, RotationalCipher.Rotate("Let' s eat, Grandma!", 21));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RotateAllLetters()
    {
        Assert.Equal(Gur dhvpx oebja sbk whzcf bire gur ynml qbt., RotationalCipher.Rotate("The quick brown fox jumps over the lazy dog.", 13));
    }
}
