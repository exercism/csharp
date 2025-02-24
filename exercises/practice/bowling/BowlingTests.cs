public class BowlingTests
{
    [Fact]
    public void Should_be_able_to_score_a_game_with_all_zeros()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(0, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_be_able_to_score_a_game_with_no_strikes_or_spares()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(90, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_spare_followed_by_zeros_is_worth_ten_points()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(10, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Points_scored_in_the_roll_after_a_spare_are_counted_twice()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [6, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(16, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Consecutive_spares_each_get_a_one_roll_bonus()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [5, 5, 3, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(31, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_spare_in_the_last_frame_gets_a_one_roll_bonus_that_is_counted_once()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 7];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(17, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_strike_earns_ten_points_in_a_frame_with_a_single_roll()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(10, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Points_scored_in_the_two_rolls_after_a_strike_are_counted_twice_as_a_bonus()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(26, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Consecutive_strikes_each_get_the_two_roll_bonus()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [10, 10, 10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(81, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_strike_in_the_last_frame_gets_a_two_roll_bonus_that_is_counted_once()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 1];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(18, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Rolling_a_spare_with_the_two_roll_bonus_does_not_get_a_bonus_roll()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 3];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(20, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Strikes_with_the_two_roll_bonus_do_not_get_bonus_rolls()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 10];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(30, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Last_two_strikes_followed_by_only_last_bonus_with_non_strike_points()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 0, 1];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(31, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_strike_with_the_one_roll_bonus_after_a_spare_in_the_last_frame_does_not_get_a_bonus()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 10];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(20, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void All_strikes_is_a_perfect_game()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(300, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Rolls_cannot_score_negative_points()
    {
        var sut = new BowlingGame();
        Assert.Throws<ArgumentException>(() => sut.Roll(-1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_roll_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        Assert.Throws<ArgumentException>(() => sut.Roll(11));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_rolls_in_a_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [5];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Bonus_roll_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(11));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_bonus_rolls_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 5];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_bonus_rolls_after_a_strike_in_the_last_frame_can_score_more_than_10_points_if_one_is_a_strike()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 6];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Equal(26, sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void The_second_bonus_rolls_after_a_strike_in_the_last_frame_cannot_be_a_strike_if_the_first_one_is_not_a_strike()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 6];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Second_bonus_roll_after_a_strike_in_the_last_frame_cannot_score_more_than_10_points()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(11));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void An_unstarted_game_cannot_be_scored()
    {
        var sut = new BowlingGame();
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void An_incomplete_game_cannot_be_scored()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_roll_if_game_already_has_ten_frames()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_bonus_rolls_for_a_strike_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Bonus_roll_for_a_spare_in_the_last_frame_must_be_rolled_before_score_can_be_calculated()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Score());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_roll_after_bonus_roll_for_spare()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 2];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_roll_after_bonus_rolls_for_strike()
    {
        var sut = new BowlingGame();
        int[] previousRolls = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 3, 2];
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        Assert.Throws<ArgumentException>(() => sut.Roll(2));
    }
}
