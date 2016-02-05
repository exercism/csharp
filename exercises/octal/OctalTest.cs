using NUnit.Framework;

[TestFixture]
public class OctalTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", ExpectedResult = 1)]
    [TestCase("10", ExpectedResult = 8, Ignore = "Remove to run test case")]
    [TestCase("17", ExpectedResult = 15, Ignore = "Remove to run test case")]
    [TestCase("11", ExpectedResult = 9, Ignore = "Remove to run test case")]
    [TestCase("130", ExpectedResult = 88, Ignore = "Remove to run test case")]
    [TestCase("2047", ExpectedResult = 1063, Ignore = "Remove to run test case")]
    [TestCase("7777", ExpectedResult = 4095, Ignore = "Remove to run test case")]
    [TestCase("1234567", ExpectedResult = 342391, Ignore = "Remove to run test case")]
    public int Octal_converts_to_decimal(string value)
    {
        return Octal.ToDecimal(value);
    }

    [TestCase("carrot", Ignore = "Remove to run test case")]
    [TestCase("8", Ignore = "Remove to run test case")]
    [TestCase("9", Ignore = "Remove to run test case")]
    [TestCase("6789", Ignore = "Remove to run test case")]
    [TestCase("abc1z", Ignore = "Remove to run test case")]
    public void Invalid_octal_is_decimal_0(string invalidValue)
    {
        Assert.That(Octal.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Octal_can_convert_formatted_strings()
    {
        Assert.That(Octal.ToDecimal("011"), Is.EqualTo(9));
    }
}