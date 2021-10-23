using System;
using Xunit;
using Exercism.Tests;

public class OverflowTests
{
    [Fact]
    public void DisplayDenomination_good()
    {
        Assert.Equal("10000000", CentralBank.DisplayDenomination(10000L, 1000L));
    }

    [Fact]
    public void DisplayDenomination_bad()
    {
        Assert.Equal("*** Too Big ***", CentralBank.DisplayDenomination(long.MaxValue / 2L, 10000L));
    }

    [Fact]
    public void DisplayGDP_good()
    {
        Assert.Equal("5550000", CentralBank.DisplayGDP(555f, 10000f));
    }

    [Fact]
    public void DisplayGDP_bad()
    {
        Assert.Equal("*** Too Big ***", CentralBank.DisplayGDP(float.MaxValue / 2L, 10000f));
    }

    [Fact]
    public void DisplaySalary_good()
    {
        Assert.Equal("5550000000", CentralBank.DisplayChiefEconomistSalary(555000m, 10000m));
    }

    [Fact]
    public void DisplaySalary_bad()
    {
        Assert.Equal("*** Much Too Big ***", CentralBank.DisplayChiefEconomistSalary(555000m,
            decimal.MaxValue / 2L));
    }
}
