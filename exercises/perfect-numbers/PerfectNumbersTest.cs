using NUnit.Framework;

[TestFixture]
public class PerfectNumbersTest
{
    [TestCase(3)]
    [TestCase(7, Ignore = "Remove to run test case")]
    [TestCase(13, Ignore = "Remove to run test case")]
    public void Can_classify_deficient_numbers(int number)
    {
        Assert.That(PerfectNumbers.Classify(number), Is.EqualTo(NumberType.Deficient));
    }
    
    [TestCase(6, Ignore = "Remove to run test case")]
    [TestCase(28, Ignore = "Remove to run test case")]
    [TestCase(496, Ignore = "Remove to run test case")]
    public void Can_classify_perfect_numbers(int number)
    {
        Assert.That(PerfectNumbers.Classify(number), Is.EqualTo(NumberType.Perfect));
    }
    
    [TestCase(12, Ignore = "Remove to run test case")]
    [TestCase(18, Ignore = "Remove to run test case")]
    [TestCase(20, Ignore = "Remove to run test case")]
    public void Can_classify_abundant_numbers(int number)
    {
        Assert.That(PerfectNumbers.Classify(number), Is.EqualTo(NumberType.Abundant));
    }
}