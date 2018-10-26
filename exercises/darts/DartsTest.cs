// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class DartsTest
{
    [Fact]
    public void A_dart_lands_outside_the_target()
    {
        Assert.Equal(0, Darts.Score(15.3, 13.2));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_just_in_the_border_of_the_target()
    {
        Assert.Equal(1, Darts.Score(10, 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_in_the_middle_circle()
    {
        Assert.Equal(5, Darts.Score(3, 3.7));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_right_in_the_border_between_outside_and_middle_circles()
    {
        Assert.Equal(5, Darts.Score(0, 5));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_dart_lands_in_the_inner_circle()
    {
        Assert.Equal(10, Darts.Score(0, 0));
    }
}