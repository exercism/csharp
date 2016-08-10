using NUnit.Framework;

[TestFixture]
public class TrinaryTest
{
    [TestCase("1", ExpectedResult = 1)]
    [TestCase("2", ExpectedResult = 2, Ignore = "Remove to run test case")]
    [TestCase("10", ExpectedResult = 3, Ignore = "Remove to run test case")]
    [TestCase("11", ExpectedResult = 4, Ignore = "Remove to run test case")]
    [TestCase("100", ExpectedResult = 9, Ignore = "Remove to run test case")]
    [TestCase("112", ExpectedResult = 14, Ignore = "Remove to run test case")]
    [TestCase("222", ExpectedResult = 26, Ignore = "Remove to run test case")]
    [TestCase("1122000120", ExpectedResult = 32091, Ignore = "Remove to run test case")]
    public int Trinary_converts_to_decimal(string value)
    {
        return Trinary.ToDecimal(value);
    }

    [TestCase("carrot", Ignore = "Remove to run test case")]
    [TestCase("3", Ignore = "Remove to run test case")]
    [TestCase("6", Ignore = "Remove to run test case")]
    [TestCase("9", Ignore = "Remove to run test case")]
    [TestCase("124578", Ignore = "Remove to run test case")]
    [TestCase("abc1z", Ignore = "Remove to run test case")]
    public void Invalid_trinary_is_decimal_0(string invalidValue)
    {
        Assert.That(Trinary.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Trinary_can_convert_formatted_strings()
    {
        Assert.That(Trinary.ToDecimal("011"), Is.EqualTo(4));
    }
}