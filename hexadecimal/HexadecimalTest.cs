using NUnit.Framework;

[TestFixture]
public class HexadecimalTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", Result = 1)]
    [TestCase("c", Result = 12, Ignore = true)]
    [TestCase("10", Result = 16, Ignore = true)]
    [TestCase("af", Result = 175, Ignore = true)]
    [TestCase("100", Result = 256, Ignore = true)]
    [TestCase("19ace", Result = 105166, Ignore = true)]
    [TestCase("19ace", Result = 105166, Ignore = true)]
    public int Hexadecimal_converts_to_decimal(string hexadecimal)
    {
        return Hexadecimal.ToDecimal(hexadecimal);
    }

    [Ignore]
    [Test]
    public void Invalid_hexadecimal_is_decimal_0()
    {
        Assert.That(Hexadecimal.ToDecimal("carrot"), Is.EqualTo(0));
    }

    [TestCase("000000", Result = 0, Ignore = true)]
    [TestCase("ffffff", Result = 16777215, Ignore = true)]
    [TestCase("ffff00", Result = 16776960, Ignore = true)]
    public int Octal_can_convert_formatted_strings(string hexidecimal)
    {
        return Hexadecimal.ToDecimal(hexidecimal);
    }
}