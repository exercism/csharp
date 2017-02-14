using Xunit;

public class NthPrimeTest
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 5)]
    [InlineData(4, 7)]
    [InlineData(5, 11)]
    [InlineData(6, 13)]
    [InlineData(7, 17)]
    [InlineData(8, 19)]
    [InlineData(1000, 7919)]
    [InlineData(10000, 104729)]
    [InlineData(10001, 104743)]
    public void Nth_prime_calculated(int nth, int expected)
    {
        Assert.Equal(expected, NthPrime.Nth(nth));
    }
}