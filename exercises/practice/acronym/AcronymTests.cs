using Xunit;

public class AcronymTests
{
    [Fact]
    public void Basic()
    {
        Assert.Equal("PNG", Acronym.Abbreviate("Portable Network Graphics"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LowercaseWords()
    {
        Assert.Equal("ROR", Acronym.Abbreviate("Ruby on Rails"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Punctuation()
    {
        Assert.Equal("FIFO", Acronym.Abbreviate("First In, First Out"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AllCapsWord()
    {
        Assert.Equal("GIMP", Acronym.Abbreviate("GNU Image Manipulation Program"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void PunctuationWithoutWhitespace()
    {
        Assert.Equal("CMOS", Acronym.Abbreviate("Complementary metal-oxide semiconductor"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void VeryLongAbbreviation()
    {
        Assert.Equal("ROTFLSHTMDCOALM", Acronym.Abbreviate("Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ConsecutiveDelimiters()
    {
        Assert.Equal("SIMUFTA", Acronym.Abbreviate("Something - I made up from thin air"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apostrophes()
    {
        Assert.Equal("HC", Acronym.Abbreviate("Halley's Comet"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void UnderscoreEmphasis()
    {
        Assert.Equal("TRNT", Acronym.Abbreviate("The Road _Not_ Taken"));
    }
}
