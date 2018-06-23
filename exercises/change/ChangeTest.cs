// This file was auto-generated based on version 1.2.0 of the canonical data.

using System;
using Xunit;

public class ChangeTest
{
    [Fact]
    public void Single_coin_change()
    {
        var coins = new[] { 1, 5, 10, 25, 100 };
        var target = 25;
        var expected = new[] { 25 };
        Assert.Equal(expected, Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_coin_change()
    {
        var coins = new[] { 1, 5, 10, 25, 100 };
        var target = 15;
        var expected = new[] { 5, 10 };
        Assert.Equal(expected, Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Change_with_lilliputian_coins()
    {
        var coins = new[] { 1, 4, 15, 20, 50 };
        var target = 23;
        var expected = new[] { 4, 4, 15 };
        Assert.Equal(expected, Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Change_with_lower_elbonia_coins()
    {
        var coins = new[] { 1, 5, 10, 21, 25 };
        var target = 63;
        var expected = new[] { 21, 21, 21 };
        Assert.Equal(expected, Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Large_target_values()
    {
        var coins = new[] { 1, 2, 5, 10, 20, 50, 100 };
        var target = 999;
        var expected = new[] { 2, 2, 5, 20, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
        Assert.Equal(expected, Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Possible_change_without_unit_coins_available()
    {
        var coins = new[] { 2, 5, 10, 20, 50 };
        var target = 21;
        var expected = new[] { 2, 2, 2, 5, 10 };
        Assert.Equal(expected, Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Another_possible_change_without_unit_coins_available()
    {
        var coins = new[] { 4, 5 };
        var target = 27;
        var expected = new[] { 4, 4, 4, 5, 5, 5 };
        Assert.Equal(expected, Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_coins_make_0_change()
    {
        var coins = new[] { 1, 5, 10, 21, 25 };
        var target = 0;
        Assert.Empty(Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Error_testing_for_change_smaller_than_the_smallest_of_coins()
    {
        var coins = new[] { 5, 10 };
        var target = 3;
        Assert.Throws<ArgumentException>(() => Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Error_if_no_combination_can_add_up_to_target()
    {
        var coins = new[] { 5, 10 };
        var target = 94;
        Assert.Throws<ArgumentException>(() => Change.FindFewestCoins(coins, target));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cannot_find_negative_change_values()
    {
        var coins = new[] { 1, 2, 5 };
        var target = -5;
        Assert.Throws<ArgumentException>(() => Change.FindFewestCoins(coins, target));
    }
}