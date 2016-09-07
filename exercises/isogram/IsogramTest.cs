using NUnit.Framework;

[TestFixture]
public class IsogramTest
{
    [TestCase("duplicates", ExpectedResult = true)]
    [TestCase("eleven", ExpectedResult = false, Ignore = "Remove to run test case")]
    [TestCase("subdermatoglyphic", ExpectedResult = true, Ignore = "Remove to run test case")]
    [TestCase("Alphabet", ExpectedResult = false, Ignore = "Remove to run test case")]
    [TestCase("thumbscrew-japingly", ExpectedResult = true, Ignore = "Remove to run test case")]
    [TestCase("Hjelmqvist-Gryb-Zock-Pfund-Wax", ExpectedResult = true, Ignore = "Remove to run test case")]
    [TestCase("Heizölrückstoßabdämpfung", ExpectedResult = true, Ignore = "Remove to run test case")]
    [TestCase("the quick brown fox", ExpectedResult = false, Ignore = "Remove to run test case")]
    [TestCase("Emily Jung Schwartzkopf", ExpectedResult = true, Ignore = "Remove to run test case")]
    [TestCase("éléphant", ExpectedResult = false, Ignore = "Remove to run test case")]
    public bool Isogram_correctly_detects_isograms(string input)
    {
        return Isogram.IsIsogram(input);
    }
}