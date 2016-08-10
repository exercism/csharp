using NUnit.Framework;

[TestFixture]
public class HexadecimalTest
{
    [TestCase("1", ExpectedResult = 1)]
    [TestCase("c", ExpectedResult = 12, Ignore = "Remove to run test case")]
    [TestCase("10", ExpectedResult = 16, Ignore = "Remove to run test case")]
    [TestCase("af", ExpectedResult = 175, Ignore = "Remove to run test case")]
    [TestCase("100", ExpectedResult = 256, Ignore = "Remove to run test case")]
    [TestCase("19ace", ExpectedResult = 105166, Ignore = "Remove to run test case")]
    [TestCase("19ace", ExpectedResult = 105166, Ignore = "Remove to run test case")]
    public int Hexadecimal_converts_to_decimal(string hexadecimal)
    {
        return Hexadecimal.ToDecimal(hexadecimal);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Invalid_hexadecimal_is_decimal_0()
    {
        Assert.That(Hexadecimal.ToDecimal("carrot"), Is.EqualTo(0));
    }

    [TestCase("000000", ExpectedResult = 0, Ignore = "Remove to run test case")]
    [TestCase("ffffff", ExpectedResult = 16777215, Ignore = "Remove to run test case")]
    [TestCase("ffff00", ExpectedResult = 16776960, Ignore = "Remove to run test case")]
    public int Octal_can_convert_formatted_strings(string hexidecimal)
    {
        return Hexadecimal.ToDecimal(hexidecimal);
    }
}