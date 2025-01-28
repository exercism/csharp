using Xunit;

public class LeapTests
{
    [Fact]
    public void Year_not_divisible_by4_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(2015));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by2_not_divisible_by4_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(1970));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by4_not_divisible_by100_in_leap_year()
    {
        Assert.True(Leap.IsLeapYear(1996));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by4_and5_is_still_a_leap_year()
    {
        Assert.True(Leap.IsLeapYear(1960));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by100_not_divisible_by400_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(2100));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by100_but_not_by3_is_still_not_a_leap_year()
    {
        Assert.False(Leap.IsLeapYear(1900));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by400_is_leap_year()
    {
        Assert.True(Leap.IsLeapYear(2000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by400_but_not_by125_is_still_a_leap_year()
    {
        Assert.True(Leap.IsLeapYear(2400));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Year_divisible_by200_not_divisible_by400_in_common_year()
    {
        Assert.False(Leap.IsLeapYear(1800));
    }
}
