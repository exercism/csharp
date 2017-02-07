using Xunit;

public class PerfectNumbersTest
{
    [InlineData(3)]
    [InlineData(7)]
    [InlineData(13)]
    public void Can_classify_deficient_numbers(int number)
    {
        Assert.Equal(NumberType.Deficient, PerfectNumbers.Classify(number));
    }
    
    [InlineData(6)]
    [InlineData(28)]
    [InlineData(496)]
    public void Can_classify_perfect_numbers(int number)
    {
        Assert.Equal(NumberType.Perfect, PerfectNumbers.Classify(number));
    }
    
    [InlineData(12)]
    [InlineData(18)]
    [InlineData(20)]
    public void Can_classify_abundant_numbers(int number)
    {
        Assert.Equal(NumberType.Abundant, PerfectNumbers.Classify(number));
    }
}