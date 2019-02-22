// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class DartsTest
{
    [Fact]
    public void A_dart_lands_outside_the_target()
    {
        Assert.Equal(0, Darts.Score(-9, 9));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_just_in_the_border_of_the_target()
    {
        Assert.Equal(1, Darts.Score(0, 10));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_in_the_outer_circle()
    {
        Assert.Equal(1, Darts.Score(4, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_right_in_the_border_between_outer_and_middle_circles()
    {
        Assert.Equal(5, Darts.Score(5, 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_in_the_middle_circle()
    {
        Assert.Equal(5, Darts.Score(0.8, -0.8));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_right_in_the_border_between_middle_and_inner_circles()
    {
        Assert.Equal(10, Darts.Score(0, -1));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_in_the_inner_circle()
    {
        Assert.Equal(10, Darts.Score(-0.1, -0.1));
    }
}