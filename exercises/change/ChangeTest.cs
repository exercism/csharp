using System;
using Xunit;

public class ChangeTest
{
    [Fact]
    public void Single_coin_change()
    {
        var actual = new[] { 1, 5, 10, 25, 100 };
        var target = 25;
        var expected = new[] { 25 };
        Assert.Equal(expected, Change.Calculate(target, actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_coin_change()
    {
        var actual = new[] { 1, 5, 10, 25, 100 };
        var target = 15;
        var expected = new[] { 5, 10 };
        Assert.Equal(expected, Change.Calculate(target, actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void Change_with_Lilliputian_Coins()
    {
        var actual = new[] { 1, 4, 15, 20, 50 };
        var target = 23;
        var expected = new[] { 4, 4, 15 };
        Assert.Equal(expected, Change.Calculate(target, actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void Change_with_Lower_Elbonia_Coins()
    {
        var actual = new[] { 1, 5, 10, 21, 25 };
        var target = 63;
        var expected = new[] { 21, 21, 21 };
        Assert.Equal(expected, Change.Calculate(target, actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void Large_target_values()
    {
        var actual = new[] { 1, 2, 5, 10, 20, 50, 100 };
        var target = 999;
        var expected = new[] { 2, 2, 5, 20, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
        Assert.Equal(expected, Change.Calculate(target, actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_coins_make_0_change()
    {
        var actual = new[] { 1, 5, 10, 21, 25 };
        var target = 0;
        var expected = new int[0];
        Assert.Equal(expected, Change.Calculate(target, actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void Error_testing_for_change_smaller_than_the_smallest_of_coins()
    {
        var actual = new[] { 5, 10 };
        var target = 3;
        Assert.Throws<ArgumentException>(() => Change.Calculate(target, actual));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cannot_find_negative_change_values()
    {
        var actual = new[] { 1, 2, 5 };
        var target = -5;
        Assert.Throws<ArgumentException>(() => Change.Calculate(target, actual));
    }
}
