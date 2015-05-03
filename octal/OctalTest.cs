using NUnit.Framework;

[TestFixture]
public class OctalTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", Result = 1)]
    [TestCase("10", Result = 8, Ignore = true)]
    [TestCase("17", Result = 15, Ignore = true)]
    [TestCase("11", Result = 9, Ignore = true)]
    [TestCase("130", Result = 88, Ignore = true)]
    [TestCase("2047", Result = 1063, Ignore = true)]
    [TestCase("7777", Result = 4095, Ignore = true)]
    [TestCase("1234567", Result = 342391, Ignore = true)]
    public int Octal_converts_to_decimal(string value)
    {
        return Octal.ToDecimal(value);
    }

    [TestCase("carrot", Ignore = true)]
    [TestCase("8", Ignore = true)]
    [TestCase("9", Ignore = true)]
    [TestCase("6789", Ignore = true)]
    [TestCase("abc1z", Ignore = true)]
    public void Invalid_octal_is_decimal_0(string invalidValue)
    {
        Assert.That(Octal.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void Octal_can_convert_formatted_strings()
    {
        Assert.That(Octal.ToDecimal("011"), Is.EqualTo(9));
    }
}