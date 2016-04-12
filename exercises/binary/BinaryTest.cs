using NUnit.Framework;

[TestFixture]
public class BinaryTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", ExpectedResult = 1)]
    [TestCase("10", ExpectedResult = 2, Ignore = "Remove to run test case")]
    [TestCase("11", ExpectedResult = 3, Ignore = "Remove to run test case")]
    [TestCase("100", ExpectedResult = 4, Ignore = "Remove to run test case")]
    [TestCase("1001", ExpectedResult = 9, Ignore = "Remove to run test case")]
    [TestCase("11010", ExpectedResult = 26, Ignore = "Remove to run test case")]
    [TestCase("10001101000", ExpectedResult = 1128, Ignore = "Remove to run test case")]
    public int Binary_converts_to_decimal(string binary)
    {
        return Binary.ToDecimal(binary);
    }
    
    [TestCase("carrot", Ignore = "Remove to run test case")]
    [TestCase("2", Ignore = "Remove to run test case")]
    [TestCase("5", Ignore = "Remove to run test case")]
    [TestCase("9", Ignore = "Remove to run test case")]
    [TestCase("a10", Ignore = "Remove to run test case")]
    [TestCase("100b", Ignore = "Remove to run test case")]
    [TestCase("10c01", Ignore = "Remove to run test case")]
    [TestCase("134678", Ignore = "Remove to run test case")]
    [TestCase("abc10z", Ignore = "Remove to run test case")]
    public void Invalid_binary_is_decimal_0(string invalidValue)
    {
        Assert.That(Binary.ToDecimal(invalidValue), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Binary_can_convert_formatted_strings()
    {
        Assert.That(Binary.ToDecimal("011"), Is.EqualTo(3));
    }
}