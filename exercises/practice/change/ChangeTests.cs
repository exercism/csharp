using System;
using Xunit;

public class ChangeTests
{
    [Fact]
    public void Change_for_1_cent()
    {
        int[] coins = [1, 5, 10, 25];
        int[] expected = [1];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_coin_change()
    {
        int[] coins = [1, 5, 10, 25, 100];
        int[] expected = [25];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 25));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_coin_change()
    {
        int[] coins = [1, 5, 10, 25, 100];
        int[] expected = [5, 10];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 15));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Change_with_lilliputian_coins()
    {
        int[] coins = [1, 4, 15, 20, 50];
        int[] expected = [4, 4, 15];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 23));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Change_with_lower_elbonia_coins()
    {
        int[] coins = [1, 5, 10, 21, 25];
        int[] expected = [21, 21, 21];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 63));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Large_target_values()
    {
        int[] coins = [1, 2, 5, 10, 20, 50, 100];
        int[] expected = [2, 2, 5, 20, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 999));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Possible_change_without_unit_coins_available()
    {
        int[] coins = [2, 5, 10, 20, 50];
        int[] expected = [2, 2, 2, 5, 10];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 21));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Another_possible_change_without_unit_coins_available()
    {
        int[] coins = [4, 5];
        int[] expected = [4, 4, 4, 5, 5, 5];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 27));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_greedy_approach_is_not_optimal()
    {
        int[] coins = [1, 10, 11];
        int[] expected = [10, 10];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 20));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_coins_make_0_change()
    {
        int[] coins = [1, 5, 10, 21, 25];
        int[] expected = [];
        Assert.Equal(expected, Change.FindFewestCoins(coins, 0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Error_testing_for_change_smaller_than_the_smallest_of_coins()
    {
        int[] coins = [5, 10];
        Assert.Throws<ArgumentException>(() => Change.FindFewestCoins(coins, 3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Error_if_no_combination_can_add_up_to_target()
    {
        int[] coins = [5, 10];
        Assert.Throws<ArgumentException>(() => Change.FindFewestCoins(coins, 94));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_find_negative_change_values()
    {
        int[] coins = [1, 2, 5];
        Assert.Throws<ArgumentException>(() => Change.FindFewestCoins(coins, -5));
    }
}
