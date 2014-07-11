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
        return new Trinary(value).ToDecimal();
    }

    [Ignore]
    [Test]
    public void Invalid_trinary_is_decimal_0()
    {
        Assert.That(new Trinary("carrot").ToDecimal(), Is.EqualTo(0));
    }
}