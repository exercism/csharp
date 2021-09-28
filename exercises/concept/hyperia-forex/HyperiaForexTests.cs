using System;
using Xunit;
using Exercism.Tests;

public class OperatorOverloadingTests
{
    [Fact]
    public void Equality_true()
    {
        Assert.True(new CurrencyAmount(55, "HD") == new CurrencyAmount(55, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Equality_false()
    {
        Assert.False(new CurrencyAmount(55, "HD") == new CurrencyAmount(60, "USD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Equality_bad()
    {
        Assert.Throws<ArgumentException>(() => new CurrencyAmount(55, "HD") == new CurrencyAmount(60, "USD"));
    }
}
