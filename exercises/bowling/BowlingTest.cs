using System.Collections.Generic;
using Xunit;

public class BowlingTest
{
    [Fact]
    public void Should_be_able_to_score_a_game_with_all_zeros()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(0, game.Score());
    }

    [Fact]
    public void Should_be_able_to_score_a_game_with_no_strikes_or_spares()
    {
        var rolls = new[] { 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(90, game.Score());
    }

    [Fact]
    public void A_spare_followed_by_zeros_is_worth_ten_points()
    {
        var rolls = new[] { 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(10, game.Score());
    }

    [Fact]
    public void Points_scored_in_the_roll_after_a_spare_are_counted_twice()
    {
        var rolls = new[] { 6, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(16, game.Score());
    }

    [Fact]
    public void Consecutive_spares_each_get_a_one_roll_bonus()
    {
        var rolls = new[] { 5, 5, 3, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(31, game.Score());
    }

    [Fact]
    public void A_spare_in_the_last_frame_gets_a_one_roll_bonus_that_is_counted_once()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 7 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(17, game.Score());
    }

    [Fact]
    public void A_strike_earns_ten_points_in_frame_with_a_single_roll()
    {
        var rolls = new[] { 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(10, game.Score());
    }

    [Fact]
    public void Points_scored_in_the_two_rolls_after_a_strike_are_counted_twice_as_a_bonus()
    {
        var rolls = new[] { 10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(26, game.Score());
    }

    [Fact]
    public void Consecutive_strikes_each_get_the_two_roll_bonus()
    {
        var rolls = new[] { 10, 10, 10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(81, game.Score());
    }

    [Fact]
    public void A_strike_in_the_last_frame_gets_a_two_roll_bonus_that_is_counted_once()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 1 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(18, game.Score());
    }

    [Fact]
    public void Rolling_a_spare_with_the_two_roll_bonus_does_not_get_a_bonus_roll()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 3 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(20, game.Score());
    }

    [Fact]
    public void Strikes_with_the_two_roll_bonus_do_not_get_bonus_rolls()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 10 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(30, game.Score());
    }

    [Fact]
    public void A_strike_with_the_one_roll_bonus_after_a_spare_in_the_last_frame_does_not_get_a_bonus()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 10 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(20, game.Score());
    }

    [Fact]
    public void All_strikes_is_a_perfect_game()
    {
        var rolls = new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Equal(300, game.Score());
    }

    [Fact]
    public void Rolls_can_not_score_negative_points()
    {
        var rolls = new[] { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void A_roll_can_not_score_more_than_10_points()
    {
        var rolls = new[] { 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void Two_rolls_in_a_frame_can_not_score_more_than_10_points()
    {
        var rolls = new[] { 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void Two_bonus_rolls_after_a_strike_in_the_last_frame_can_not_score_more_than_10_points()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 5, 6 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void An_unstarted_game_can_not_be_scored()
    {
        var rolls = new int[0];
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void An_incomplete_game_can_not_be_scored()
    {
        var rolls = new[] { 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void A_game_with_more_than_ten_frames_can_not_be_scored()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void Bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void Both_bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }

    [Fact]
    public void Bonus_roll_for_a_spare_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var rolls = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3 };
        var game = RollMany(rolls, new BowlingGame());
        Assert.Null(game.Score());
    }
    
    private static BowlingGame RollMany(IEnumerable<int> rolls, BowlingGame game)
    {
        foreach (var pins in rolls)
        {
            game.Roll(pins);
        }

        return game;
    }
}