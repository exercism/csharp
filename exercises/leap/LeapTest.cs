using Xunit;

public class LeapTest
{
    [Fact]
    public void Year_not_divisible_by_4_is_common_year()
    {
        Assert.False(Leap.IsLeapYear(2015));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_4_not_divisible_by_100_is_leap_year()
    {
        Assert.True(Leap.IsLeapYear(2016));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_100_not_divisible_by_400_is_common_year()
    {
        Assert.False(Leap.IsLeapYear(2100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Year_divisible_by_400_is_leap_year()
    {
        Assert.True(Leap.IsLeapYear(2000));
    }
}