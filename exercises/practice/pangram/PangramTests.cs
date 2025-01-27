using Xunit;

public class PangramTests
{
    [Fact]
    public void EmptySentence()
    {
        Assert.False(Pangram.IsPangram(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void PerfectLowerCase()
    {
        Assert.True(Pangram.IsPangram("abcdefghijklmnopqrstuvwxyz"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OnlyLowerCase()
    {
        Assert.True(Pangram.IsPangram("the quick brown fox jumps over the lazy dog"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MissingTheLetterX()
    {
        Assert.False(Pangram.IsPangram("a quick movement of the enemy will jeopardize five gunboats"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MissingTheLetterH()
    {
        Assert.False(Pangram.IsPangram("five boxing wizards jump quickly at it"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WithUnderscores()
    {
        Assert.True(Pangram.IsPangram("the_quick_brown_fox_jumps_over_the_lazy_dog"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WithNumbers()
    {
        Assert.True(Pangram.IsPangram("the 1 quick brown fox jumps over the 2 lazy dogs"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MissingLettersReplacedByNumbers()
    {
        Assert.False(Pangram.IsPangram("7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MixedCaseAndPunctuation()
    {
        Assert.True(Pangram.IsPangram("\"Five quacking Zephyrs jolt my wax bed.\""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AMAndAMAre26DifferentCharactersButNotAPangram()
    {
        Assert.False(Pangram.IsPangram("abcdefghijklm ABCDEFGHIJKLM"));
    }
}
