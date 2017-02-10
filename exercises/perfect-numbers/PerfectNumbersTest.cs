using Xunit;

public class PerfectNumbersTest
{
    [Theory]
    [InlineData(3)]
    [InlineData(7)]
    [InlineData(13)]
    public void Can_classify_deficient_numbers(int number)
    {
        Assert.Equal(NumberType.Deficient, PerfectNumbers.Classify(number));
    }
    
    [Theory(Skip = "Remove to run test")]
    [InlineData(6)]
    [InlineData(28)]
    [InlineData(496)]
    public void Can_classify_perfect_numbers(int number)
    {
        Assert.Equal(NumberType.Perfect, PerfectNumbers.Classify(number));
    }
    
    [Theory(Skip = "Remove to run test")]
    [InlineData(12)]
    [InlineData(18)]
    [InlineData(20)]
    public void Can_classify_abundant_numbers(int number)
    {
        Assert.Equal(NumberType.Abundant, PerfectNumbers.Classify(number));
    }
}