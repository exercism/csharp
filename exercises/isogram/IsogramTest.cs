using Xunit;

public class IsogramTest
{
    [Theory]
    [InlineData("duplicates", true)]
    [InlineData("eleven", false)]
    [InlineData("subdermatoglyphic", true)]
    [InlineData("Alphabet", false)]
    [InlineData("thumbscrew-japingly", true)]
    [InlineData("Hjelmqvist-Gryb-Zock-Pfund-Wax", true)]
    [InlineData("Heizölrückstoßabdämpfung", true)]
    [InlineData("the quick brown fox", false)]
    [InlineData("Emily Jung Schwartzkopf", true)]
    [InlineData("éléphant", false)]
    public void Isogram_correctly_detects_isograms(string input, bool expected)
    {
        Assert.Equal(expected, Isogram.IsIsogram(input));
    }
}