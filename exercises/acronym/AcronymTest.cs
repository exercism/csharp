using Xunit;

public class AcronymTest
{
    [Fact(Skip = "Remove to run test")]
    public void Empty_string_abbreviated_to_empty_string()
    {
        Assert.Equal(string.Empty, Acronym.Abbreviate(string.Empty));
    }

    [Theory]
    [InlineData("Portable Network Graphics", "PNG")]
    [InlineData("Ruby on Rails", "ROR")]
    [InlineData("HyperText Markup Language", "HTML")]
    [InlineData("First In, First Out", "FIFO")]
    [InlineData("PHP: Hypertext Preprocessor", "PHP")]
    [InlineData("Complementary metal-oxide semiconductor", "CMOS")]
    public void Phrase_abbreviated_to_acronym(string phrase, string expected)
    {
        Assert.Equal(expected, Acronym.Abbreviate(phrase));
    }
}