using System;
using Xunit;

public class OperatorOverloadingTests
{
    [Fact]
    public void Equality_true()
    {
        Assert.True(Eq(new CurrencyAmount(55, "HD"), new CurrencyAmount(55, "HD")));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Equality_false()
    {
        Assert.False(Eq(new CurrencyAmount(55, "HD"), new CurrencyAmount(60, "HD")));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Equality_bad()
    {
        Assert.Throws<ArgumentException>(() => Eq(new CurrencyAmount(55, "HD"), new CurrencyAmount(60, "USD")));
    }

    private bool Eq(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA == amountB;
    }
}
