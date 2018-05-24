// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class YachtTest
{
    [Fact]
    public void Yacht()
    {
        Assert.Equal(50, YachtGame.Score(new[] { 5, 5, 5, 5, 5 }, YachtCategory.Yacht));
    }

    [Fact(Skip = "Remove to run test")]
    public void Not_yacht()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 1, 3, 3, 2, 5 }, YachtCategory.Yacht));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ones()
    {
        Assert.Equal(3, YachtGame.Score(new[] { 1, 1, 1, 3, 5 }, YachtCategory.Ones));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ones_out_of_order()
    {
        Assert.Equal(3, YachtGame.Score(new[] { 3, 1, 1, 5, 1 }, YachtCategory.Ones));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_ones()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 4, 3, 6, 5, 5 }, YachtCategory.Ones));
    }

    [Fact(Skip = "Remove to run test")]
    public void Twos()
    {
        Assert.Equal(2, YachtGame.Score(new[] { 2, 3, 4, 5, 6 }, YachtCategory.Twos));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fours()
    {
        Assert.Equal(8, YachtGame.Score(new[] { 1, 4, 1, 4, 1 }, YachtCategory.Fours));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_counted_as_threes()
    {
        Assert.Equal(15, YachtGame.Score(new[] { 3, 3, 3, 3, 3 }, YachtCategory.Threes));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_of_3s_counted_as_fives()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 3, 3, 3, 3, 3 }, YachtCategory.Fives));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sixes()
    {
        Assert.Equal(6, YachtGame.Score(new[] { 2, 3, 4, 5, 6 }, YachtCategory.Sixes));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_house_two_small_three_big()
    {
        Assert.Equal(16, YachtGame.Score(new[] { 2, 2, 4, 4, 4 }, YachtCategory.FullHouse));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_house_three_small_two_big()
    {
        Assert.Equal(19, YachtGame.Score(new[] { 5, 3, 3, 5, 3 }, YachtCategory.FullHouse));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_pair_is_not_a_full_house()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 2, 2, 4, 4, 5 }, YachtCategory.FullHouse));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_of_a_kind_is_not_a_full_house()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 1, 4, 4, 4, 4 }, YachtCategory.FullHouse));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_is_not_a_full_house()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 2, 2, 2, 2, 2 }, YachtCategory.FullHouse));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_of_a_kind()
    {
        Assert.Equal(24, YachtGame.Score(new[] { 6, 6, 4, 6, 6 }, YachtCategory.FourOfAKind));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_can_be_scored_as_four_of_a_kind()
    {
        Assert.Equal(12, YachtGame.Score(new[] { 3, 3, 3, 3, 3 }, YachtCategory.FourOfAKind));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_house_is_not_four_of_a_kind()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 3, 3, 3, 5, 5 }, YachtCategory.FourOfAKind));
    }

    [Fact(Skip = "Remove to run test")]
    public void Little_straight()
    {
        Assert.Equal(30, YachtGame.Score(new[] { 3, 5, 4, 1, 2 }, YachtCategory.LittleStraight));
    }

    [Fact(Skip = "Remove to run test")]
    public void Little_straight_as_big_straight()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 1, 2, 3, 4, 5 }, YachtCategory.BigStraight));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_in_order_but_not_a_little_straight()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 1, 1, 2, 3, 4 }, YachtCategory.LittleStraight));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_pairs_but_not_a_little_straight()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 1, 2, 3, 4, 6 }, YachtCategory.LittleStraight));
    }

    [Fact(Skip = "Remove to run test")]
    public void Minimum_is_1_maximum_is_5_but_not_a_little_straight()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 1, 1, 3, 4, 5 }, YachtCategory.LittleStraight));
    }

    [Fact(Skip = "Remove to run test")]
    public void Big_straight()
    {
        Assert.Equal(30, YachtGame.Score(new[] { 4, 6, 2, 5, 3 }, YachtCategory.BigStraight));
    }

    [Fact(Skip = "Remove to run test")]
    public void Big_straight_as_little_straight()
    {
        Assert.Equal(0, YachtGame.Score(new[] { 6, 5, 4, 3, 2 }, YachtCategory.LittleStraight));
    }

    [Fact(Skip = "Remove to run test")]
    public void Choice()
    {
        Assert.Equal(23, YachtGame.Score(new[] { 3, 3, 5, 6, 6 }, YachtCategory.Choice));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_as_choice()
    {
        Assert.Equal(10, YachtGame.Score(new[] { 2, 2, 2, 2, 2 }, YachtCategory.Choice));
    }
}