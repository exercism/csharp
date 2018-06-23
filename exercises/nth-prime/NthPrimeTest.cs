// This file was auto-generated based on version 2.1.0 of the canonical data.

using System;
using Xunit;

public class NthPrimeTest
{
    [Fact]
    public void First_prime()
    {
        Assert.Equal(2, NthPrime.Prime(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_prime()
    {
        Assert.Equal(3, NthPrime.Prime(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sixth_prime()
    {
        Assert.Equal(13, NthPrime.Prime(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Big_prime()
    {
        Assert.Equal(104743, NthPrime.Prime(10001));
    }

    [Fact(Skip = "Remove to run test")]
    public void There_is_no_zeroth_prime()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => NthPrime.Prime(0));
    }
}