using Xunit;

public class PerfectNumbersTest
{
    [TestCase(3)]
    [TestCase(7, Ignore = "Remove to run test case")]
    [TestCase(13, Ignore = "Remove to run test case")]
    public void Can_classify_deficient_numbers(int number)
    {
        Assert.Equal(NumberType.Deficient, PerfectNumbers.Classify(number));
    }
    
    [TestCase(6, Ignore = "Remove to run test case")]
    [TestCase(28, Ignore = "Remove to run test case")]
    [TestCase(496, Ignore = "Remove to run test case")]
    public void Can_classify_perfect_numbers(int number)
    {
        Assert.Equal(NumberType.Perfect, PerfectNumbers.Classify(number));
    }
    
    [TestCase(12, Ignore = "Remove to run test case")]
    [TestCase(18, Ignore = "Remove to run test case")]
    [TestCase(20, Ignore = "Remove to run test case")]
    public void Can_classify_abundant_numbers(int number)
    {
        Assert.Equal(NumberType.Abundant, PerfectNumbers.Classify(number));
    }
}