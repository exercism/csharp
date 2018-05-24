// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class PrimeFactorsTest
{
    [Fact]
    public void No_factors()
    {
        Assert.Empty(PrimeFactors.Factors(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Prime_number()
    {
        Assert.Equal(new[] { 2 }, PrimeFactors.Factors(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Square_of_a_prime()
    {
        Assert.Equal(new[] { 3, 3 }, PrimeFactors.Factors(9));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cube_of_a_prime()
    {
        Assert.Equal(new[] { 2, 2, 2 }, PrimeFactors.Factors(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Product_of_primes_and_non_primes()
    {
        Assert.Equal(new[] { 2, 2, 3 }, PrimeFactors.Factors(12));
    }

    [Fact(Skip = "Remove to run test")]
    public void Product_of_primes()
    {
        Assert.Equal(new[] { 5, 17, 23, 461 }, PrimeFactors.Factors(901255));
    }

    [Fact(Skip = "Remove to run test")]
    public void Factors_include_a_large_prime()
    {
        Assert.Equal(new[] { 11, 9539, 894119 }, PrimeFactors.Factors(93819012551));
    }
}