using NUnit.Framework;

[TestFixture]
public class TrinaryTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", Result = 1)]
    [TestCase("2", Result = 2, Ignore = true)]
    [TestCase("10", Result = 3, Ignore = true)]
    [TestCase("11", Result = 4, Ignore = true)]
    [TestCase("100", Result = 9, Ignore = true)]
    [TestCase("112", Result = 14, Ignore = true)]
    [TestCase("222", Result = 26, Ignore = true)]
    [TestCase("1122000120", Result = 32091, Ignore = true)]
    public int Trinary_converts_to_decimal(string value)
    {
        return Trinary.ToDecimal(value);
    }

    [TestCase("carrot", Ignore = true)]
    [TestCase("3", Ignore = true)]
    [TestCase("6", Ignore = true)]
    [TestCase("9", Ignore = true)]
    [TestCase("124578", Ignore = true)]
    [TestCase("abc1z", Ignore = true)]
    public void Invalid_trinary_is_decimal_0(string invalidValue)
    {
        Assert.That(Trinary.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void Trinary_can_convert_formatted_strings()
    {
        Assert.That(Trinary.ToDecimal("011"), Is.EqualTo(4));
    }
}