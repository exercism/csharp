using Xunit;

public class IsogramTests
{
    [Fact]
    public void EmptyString()
    {
        Assert.True(Isogram.IsIsogram(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void IsogramWithOnlyLowerCaseCharacters()
    {
        Assert.True(Isogram.IsIsogram("isogram"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WordWithOneDuplicatedCharacter()
    {
        Assert.False(Isogram.IsIsogram("eleven"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WordWithOneDuplicatedCharacterFromTheEndOfTheAlphabet()
    {
        Assert.False(Isogram.IsIsogram("zzyzx"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LongestReportedEnglishIsogram()
    {
        Assert.True(Isogram.IsIsogram("subdermatoglyphic"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WordWithDuplicatedCharacterInMixedCase()
    {
        Assert.False(Isogram.IsIsogram("Alphabet"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WordWithDuplicatedCharacterInMixedCaseLowercaseFirst()
    {
        Assert.False(Isogram.IsIsogram("alphAbet"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void HypotheticalIsogrammicWordWithHyphen()
    {
        Assert.True(Isogram.IsIsogram("thumbscrew-japingly"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void HypotheticalWordWithDuplicatedCharacterFollowingHyphen()
    {
        Assert.False(Isogram.IsIsogram("thumbscrew-jappingly"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void IsogramWithDuplicatedHyphen()
    {
        Assert.True(Isogram.IsIsogram("six-year-old"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MadeUpNameThatIsAnIsogram()
    {
        Assert.True(Isogram.IsIsogram("Emily Jung Schwartzkopf"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DuplicatedCharacterInTheMiddle()
    {
        Assert.False(Isogram.IsIsogram("accentor"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SameFirstAndLastCharacters()
    {
        Assert.False(Isogram.IsIsogram("angola"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WordWithDuplicatedCharacterAndWithTwoHyphens()
    {
        Assert.False(Isogram.IsIsogram("up-to-date"));
    }
}
