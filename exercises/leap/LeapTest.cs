// This file was auto-generated based on version 1.5.1 of the canonical data.

using Xunit;

public class LeapTest
{
    [Fact]
    public void Year_not_divisible_by_4_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(2015));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_2_not_divisible_by_4_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(1970));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_4_not_divisible_by_100_in_leap_year()
    {
        Assert.True(Leap.IsLeapYear(1996));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_100_not_divisible_by_400_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(2100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_400_in_leap_year()
    {
        Assert.True(Leap.IsLeapYear(2000));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_200_not_divisible_by_400_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(1800));
    }
}