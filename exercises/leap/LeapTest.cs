using Xunit;

public class LeapTest
{
    [Fact(Skip = "Remove to run test")]
    public void Valid_leap_year()
    {
        Assert.True(Year.IsLeap(1996));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_leap_year()
    {
        Assert.False(Year.IsLeap(1997));
    }

    [Fact(Skip = "Remove to run test")]
    public void Turn_of_the_20th_century_is_not_a_leap_year()
    {
        Assert.False(Year.IsLeap(1900));
    }

    [Fact(Skip = "Remove to run test")]
    public void Turn_of_the_25th_century_is_a_leap_year()
    {
        Assert.True(Year.IsLeap(2400));
    }
}