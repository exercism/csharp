// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class AcronymTest
{
    [Fact]
    public void Basic()
    {
        Assert.Equal("PNG", Acronym.Abbreviate("Portable Network Graphics"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Lowercase_words()
    {
        Assert.Equal("ROR", Acronym.Abbreviate("Ruby on Rails"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Punctuation()
    {
        Assert.Equal("FIFO", Acronym.Abbreviate("First In, First Out"));
    }

    [Fact(Skip = "Remove to run test")]
    public void All_caps_words()
    {
        Assert.Equal("PHP", Acronym.Abbreviate("PHP: Hypertext Preprocessor"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_acronym_all_caps_word()
    {
        Assert.Equal("GIMP", Acronym.Abbreviate("GNU Image Manipulation Program"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Hyphenated()
    {
        Assert.Equal("CMOS", Acronym.Abbreviate("Complementary metal-oxide semiconductor"));
    }
}