// This file was auto-generated based on version 1.2.0 of the canonical data.

using System;
using System.Collections.Generic;
using Xunit;

public class BowlingTest
{
    [Fact]
    public void Should_be_able_to_score_a_game_with_all_zeros()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(0, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_be_able_to_score_a_game_with_no_strikes_or_spares()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(90, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_spare_followed_by_zeros_is_worth_ten_points()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(10, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Points_scored_in_the_roll_after_a_spare_are_counted_twice()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 6, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(16, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Consecutive_spares_each_get_a_one_roll_bonus()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 5, 5, 3, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(31, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_spare_in_the_last_frame_gets_a_one_roll_bonus_that_is_counted_once()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 7 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(17, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_strike_earns_ten_points_in_a_frame_with_a_single_roll()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(10, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Points_scored_in_the_two_rolls_after_a_strike_are_counted_twice_as_a_bonus()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(26, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Consecutive_strikes_each_get_the_two_roll_bonus()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 10, 10, 10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(81, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_strike_in_the_last_frame_gets_a_two_roll_bonus_that_is_counted_once()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 1 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(18, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rolling_a_spare_with_the_two_roll_bonus_does_not_get_a_bonus_roll()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 3 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(20, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Strikes_with_the_two_roll_bonus_do_not_get_bonus_rolls()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 10 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(30, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_strike_with_the_one_roll_bonus_after_a_spare_in_the_last_frame_does_not_get_a_bonus()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 10 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(20, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void All_strikes_is_a_perfect_game()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(300, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rolls_cannot_score_negative_points()
    {
        var sut = new BowlingGame();
        var previousRolls = Array.Empty<int>();
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(-1));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_roll_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        var previousRolls = Array.Empty<int>();
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(11));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_rolls_in_a_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 5 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Bonus_roll_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(11));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_bonus_rolls_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 5 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_bonus_rolls_after_a_strike_in_the_last_frame_can_score_more_than_10_points_if_one_is_a_strike()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 6 };
        DoRoll(previousRolls, sut);
        var actual = sut.Score();
        Assert.Equal(26, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void The_second_bonus_rolls_after_a_strike_in_the_last_frame_cannot_be_a_strike_if_the_first_one_is_not_a_strike()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 6 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_bonus_roll_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(11));
    }

    [Fact(Skip = "Remove to run test")]
    public void An_unstarted_game_cannot_be_scored()
    {
        var sut = new BowlingGame();
        var previousRolls = Array.Empty<int>();
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove to run test")]
    public void An_incomplete_game_cannot_be_scored()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove to run test")]
    public void Cannot_roll_if_game_already_has_ten_frames()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove to run test")]
    public void Bonus_roll_for_a_spare_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove to run test")]
    public void Cannot_roll_after_bonus_roll_for_spare()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 2 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cannot_roll_after_bonus_rolls_for_strike()
    {
        var sut = new BowlingGame();
        var previousRolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 3, 2 };
        DoRoll(previousRolls, sut);
        Assert.Throws<ArgumentException>(() => sut.Roll(2));
    }

    public void DoRoll(IEnumerable<int> rolls, BowlingGame sut)
    {
        foreach (var roll in rolls)
        {
            sut.Roll(roll);
        }
    }
}