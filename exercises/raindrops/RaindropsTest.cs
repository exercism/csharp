using Xunit;

public class RaindropsTest
{
    [InlineData(1, "1")]
    [InlineData(52, "52")]
    [InlineData(12121, "12121")]
    public void Non_primes_pass_through(int number, string expected)
    {
        Assert.Equal(expected, Raindrops.Convert(number));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public void Numbers_containing_3_as_a_prime_factor_give_pling(int number)
    {
        Assert.Equal("Pling", Raindrops.Convert(number));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(25)]
    public void Numbers_containing_5_as_a_prime_factor_give_plang(int number)
    {
        Assert.Equal("Plang", Raindrops.Convert(number));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData(7)]
    [InlineData(14)]
    [InlineData(49)]
    public void Numbers_containing_7_as_a_prime_factor_give_plong(int number)
    {
        Assert.Equal("Plong", Raindrops.Convert(number));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData(15, "PlingPlang")]
    [InlineData(21, "PlingPlong")]
    [InlineData(35, "PlangPlong")]
    [InlineData(105, "PlingPlangPlong")]
    public void Numbers_containing_multiple_prime_factors_give_all_results_concatenated(int number, string expected)
    {
        Assert.Equal(expected, Raindrops.Convert(number));
    }
}