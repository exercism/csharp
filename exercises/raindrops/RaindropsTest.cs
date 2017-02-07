using Xunit;

public class RaindropsTest
{
    [TestCase(1, ExpectedResult = "1")]
    [TestCase(52, ExpectedResult = "52")]
    [TestCase(12121, ExpectedResult = "12121")]
    public string Non_primes_pass_through(int number)
    {
        return Raindrops.Convert(number);
    }

    [Ignore("Remove to run test")]
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(9)]
    public void Numbers_containing_3_as_a_prime_factor_give_pling(int number)
    {
        Assert.Equal("Pling", Raindrops.Convert(number));
    }

    [Ignore("Remove to run test")]
    [TestCase(5)]
    [TestCase(10)]
    [TestCase(25)]
    public void Numbers_containing_5_as_a_prime_factor_give_plang(int number)
    {
        Assert.Equal("Plang", Raindrops.Convert(number));
    }

    [Ignore("Remove to run test")]
    [TestCase(7)]
    [TestCase(14)]
    [TestCase(49)]
    public void Numbers_containing_7_as_a_prime_factor_give_plong(int number)
    {
        Assert.Equal("Plong", Raindrops.Convert(number));
    }

    [Ignore("Remove to run test")]
    [TestCase(15, ExpectedResult = "PlingPlang")]
    [TestCase(21, ExpectedResult = "PlingPlong")]
    [TestCase(35, ExpectedResult = "PlangPlong")]
    [TestCase(105, ExpectedResult = "PlingPlangPlong")]
    public string Numbers_containing_multiple_prime_factors_give_all_results_concatenated(int number)
    {
        return Raindrops.Convert(number);
    }
}