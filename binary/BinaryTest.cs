using NUnit.Framework;

[TestFixture]
public class BinaryTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("1", Result = 1)]
    [TestCase("10", Result = 2, Ignore = true)]
    [TestCase("11", Result = 3, Ignore = true)]
    [TestCase("100", Result = 4, Ignore = true)]
    [TestCase("1001", Result = 9, Ignore = true)]
    [TestCase("11010", Result = 26, Ignore = true)]
    [TestCase("10001101000", Result = 1128, Ignore = true)]
    public int Binary_converts_to_decimal(string binary)
    {
        return new Binary(binary).ToDecimal();
    }

    [Ignore]
    [Test]
    public void Invalid_binary_is_decimal_0()
    {
        Assert.That(new Binary("carrot123").ToDecimal(), Is.EqualTo(0));
    }
}