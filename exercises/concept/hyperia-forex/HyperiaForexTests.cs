using System;
using Xunit;
using Exercism.Tests;

public class HyperiaForexTests
{
    [Fact]
    public void Equality_true()
    {
        Assert.True(new CurrencyAmount(55, "HD") == new CurrencyAmount(55, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Equality_false()
    {
        Assert.False(new CurrencyAmount(55, "HD") == new CurrencyAmount(60, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Equality_different_currencies()
    {
        Assert.Throws<ArgumentException>(() => new CurrencyAmount(55, "HD") == new CurrencyAmount(60, "USD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Inequality_true()
    {
        Assert.True(new CurrencyAmount(55, "HD") != new CurrencyAmount(60, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Inequality_false()
    {
        Assert.False(new CurrencyAmount(55, "HD") != new CurrencyAmount(55, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Inequality_different_currencies()
    {
        Assert.Throws<ArgumentException>(() => new CurrencyAmount(55, "HD") != new CurrencyAmount(60, "USD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LessThan_true()
    {
        Assert.True(new CurrencyAmount(55, "HD") < new CurrencyAmount(60, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LessThan_false()
    {
        Assert.False(new CurrencyAmount(60, "HD") < new CurrencyAmount(55, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LessThan_different_currencies()
    {
        Assert.Throws<ArgumentException>(() => new CurrencyAmount(55, "HD") < new CurrencyAmount(60, "USD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void GreaterThan_true()
    {
        Assert.True(new CurrencyAmount(60, "HD") > new CurrencyAmount(55, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void GreaterThan_false()
    {
        Assert.False(new CurrencyAmount(55, "HD") > new CurrencyAmount(60, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void GreaterThan_different_currencies()
    {
        Assert.Throws<ArgumentException>(() => new CurrencyAmount(60, "HD") > new CurrencyAmount(55, "USD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition_same_currencies()
    {
        Assert.Equal(new CurrencyAmount(155, "HD"), new CurrencyAmount(55, "HD") + new CurrencyAmount(100, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition_different_currencies()
    {
        Assert.Throws<ArgumentException>(() => new CurrencyAmount(55, "HD") + new CurrencyAmount(55, "USD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtraction_same_currencies()
    {
        Assert.Equal(new CurrencyAmount(45, "HD"), new CurrencyAmount(100, "HD") - new CurrencyAmount(55, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtraction_different_currencies()
    {
        Assert.Throws<ArgumentException>(() => new CurrencyAmount(100, "HD") - new CurrencyAmount(55, "USD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiplication_left_hand_side()
    {
        Assert.Equal(new CurrencyAmount(20, "HD"), new CurrencyAmount(10, "HD") * 2m);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiplication_right_hand_side()
    {
        Assert.Equal(new CurrencyAmount(20, "HD"), 2m * new CurrencyAmount(10, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Division()
    {
        Assert.Equal(new CurrencyAmount(5, "HD"), new CurrencyAmount(10, "HD") / 2m);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cast_to_double()
    {
        Assert.Equal(55.5d, (double)new CurrencyAmount(55.5m, "HD"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cast_to_decimal()
    {
        Assert.Equal(55.5m, (decimal)new CurrencyAmount(55.5m, "HD"));
    }
}
