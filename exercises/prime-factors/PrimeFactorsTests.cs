// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class PrimeFactorsTests
{
    [Fact]
    public void No_factors()
    {
        Assert.Empty(PrimeFactors.Factors(1L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Prime_number()
    {
        Assert.Equal(new[] { 2L }, PrimeFactors.Factors(2L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Square_of_a_prime()
    {
        Assert.Equal(new[] { 3L, 3L }, PrimeFactors.Factors(9L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cube_of_a_prime()
    {
        Assert.Equal(new[] { 2L, 2L, 2L }, PrimeFactors.Factors(8L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Product_of_primes_and_non_primes()
    {
        Assert.Equal(new[] { 2L, 2L, 3L }, PrimeFactors.Factors(12L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Product_of_primes()
    {
        Assert.Equal(new[] { 5L, 17L, 23L, 461L }, PrimeFactors.Factors(901255L));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Factors_include_a_large_prime()
    {
        Assert.Equal(new[] { 11L, 9539L, 894119L }, PrimeFactors.Factors(93819012551L));
    }
}