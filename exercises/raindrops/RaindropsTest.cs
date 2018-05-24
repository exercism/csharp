// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class RaindropsTest
{
    [Fact]
    public void The_sound_for_1_is_1()
    {
        Assert.Equal("1", Raindrops.Convert(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_3_is_pling()
    {
        Assert.Equal("Pling", Raindrops.Convert(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_5_is_plang()
    {
        Assert.Equal("Plang", Raindrops.Convert(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_7_is_plong()
    {
        Assert.Equal("Plong", Raindrops.Convert(7));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_6_is_pling_as_it_has_a_factor_3()
    {
        Assert.Equal("Pling", Raindrops.Convert(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_2_to_the_power_3_does_not_make_a_raindrop_sound_as_3_is_the_exponent_not_the_base()
    {
        Assert.Equal("8", Raindrops.Convert(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_9_is_pling_as_it_has_a_factor_3()
    {
        Assert.Equal("Pling", Raindrops.Convert(9));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_10_is_plang_as_it_has_a_factor_5()
    {
        Assert.Equal("Plang", Raindrops.Convert(10));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_14_is_plong_as_it_has_a_factor_of_7()
    {
        Assert.Equal("Plong", Raindrops.Convert(14));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_15_is_plingplang_as_it_has_factors_3_and_5()
    {
        Assert.Equal("PlingPlang", Raindrops.Convert(15));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_21_is_plingplong_as_it_has_factors_3_and_7()
    {
        Assert.Equal("PlingPlong", Raindrops.Convert(21));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_25_is_plang_as_it_has_a_factor_5()
    {
        Assert.Equal("Plang", Raindrops.Convert(25));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_27_is_pling_as_it_has_a_factor_3()
    {
        Assert.Equal("Pling", Raindrops.Convert(27));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_35_is_plangplong_as_it_has_factors_5_and_7()
    {
        Assert.Equal("PlangPlong", Raindrops.Convert(35));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_49_is_plong_as_it_has_a_factor_7()
    {
        Assert.Equal("Plong", Raindrops.Convert(49));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_52_is_52()
    {
        Assert.Equal("52", Raindrops.Convert(52));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_105_is_plingplangplong_as_it_has_factors_3_5_and_7()
    {
        Assert.Equal("PlingPlangPlong", Raindrops.Convert(105));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_sound_for_3125_is_plang_as_it_has_a_factor_5()
    {
        Assert.Equal("Plang", Raindrops.Convert(3125));
    }
}