// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class YachtTest
{
    [Fact]
    // generated but commented out/renamed as it creates collision with the 'Yacht' class name
    // public void Yacht()
    public void Yacht_()
    {
        Assert.Equal(50, Yacht.Score(new[] { 5, 5, 5, 5, 5 }, "yacht"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Not_yacht()
    {
        Assert.Equal(0, Yacht.Score(new[] { 1, 3, 3, 2, 5 }, "yacht"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ones()
    {
        Assert.Equal(3, Yacht.Score(new[] { 1, 1, 1, 3, 5 }, "ones"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ones_out_of_order()
    {
        Assert.Equal(3, Yacht.Score(new[] { 3, 1, 1, 5, 1 }, "ones"));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_ones()
    {
        Assert.Equal(0, Yacht.Score(new[] { 4, 3, 6, 5, 5 }, "ones"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Twos()
    {
        Assert.Equal(2, Yacht.Score(new[] { 2, 3, 4, 5, 6 }, "twos"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fours()
    {
        Assert.Equal(8, Yacht.Score(new[] { 1, 4, 1, 4, 1 }, "fours"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_counted_as_threes()
    {
        Assert.Equal(15, Yacht.Score(new[] { 3, 3, 3, 3, 3 }, "threes"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_of_3s_counted_as_fives()
    {
        Assert.Equal(0, Yacht.Score(new[] { 3, 3, 3, 3, 3 }, "fives"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sixes()
    {
        Assert.Equal(6, Yacht.Score(new[] { 2, 3, 4, 5, 6 }, "sixes"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_house_two_small_three_big()
    {
        Assert.Equal(16, Yacht.Score(new[] { 2, 2, 4, 4, 4 }, "full house"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_house_three_small_two_big()
    {
        Assert.Equal(19, Yacht.Score(new[] { 5, 3, 3, 5, 3 }, "full house"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_pair_is_not_a_full_house()
    {
        Assert.Equal(0, Yacht.Score(new[] { 2, 2, 4, 4, 5 }, "full house"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_is_not_a_full_house()
    {
        Assert.Equal(0, Yacht.Score(new[] { 2, 2, 2, 2, 2 }, "full house"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_of_a_kind()
    {
        Assert.Equal(24, Yacht.Score(new[] { 6, 6, 4, 6, 6 }, "four of a kind"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_can_be_scored_as_four_of_a_kind()
    {
        Assert.Equal(12, Yacht.Score(new[] { 3, 3, 3, 3, 3 }, "four of a kind"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_house_is_not_four_of_a_kind()
    {
        Assert.Equal(0, Yacht.Score(new[] { 3, 3, 3, 5, 5 }, "four of a kind"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Little_straight()
    {
        Assert.Equal(30, Yacht.Score(new[] { 3, 5, 4, 1, 2 }, "little straight"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Little_straight_as_big_straight()
    {
        Assert.Equal(0, Yacht.Score(new[] { 1, 2, 3, 4, 5 }, "big straight"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_in_order_but_not_a_little_straight()
    {
        Assert.Equal(0, Yacht.Score(new[] { 1, 1, 2, 3, 4 }, "little straight"));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_pairs_but_not_a_little_straight()
    {
        Assert.Equal(0, Yacht.Score(new[] { 1, 2, 3, 4, 6 }, "little straight"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Minimum_is_1_maximum_is_5_but_not_a_little_straight()
    {
        Assert.Equal(0, Yacht.Score(new[] { 1, 1, 3, 4, 5 }, "little straight"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Big_straight()
    {
        Assert.Equal(30, Yacht.Score(new[] { 4, 6, 2, 5, 3 }, "big straight"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Big_straight_as_little_straight()
    {
        Assert.Equal(0, Yacht.Score(new[] { 6, 5, 4, 3, 2 }, "little straight"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Choice()
    {
        Assert.Equal(23, Yacht.Score(new[] { 3, 3, 5, 6, 6 }, "choice"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Yacht_as_choice()
    {
        Assert.Equal(10, Yacht.Score(new[] { 2, 2, 2, 2, 2 }, "choice"));
    }
}