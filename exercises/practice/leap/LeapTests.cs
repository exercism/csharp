using Xunit;

public class LeapTests
{
    [Fact]
    public void YearNotDivisibleBy4InCommonYear()
    {
        Assert.False(Leap.IsLeapYear(2015));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy2NotDivisibleBy4InCommonYear()
    {
        Assert.False(Leap.IsLeapYear(1970));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy4NotDivisibleBy100InLeapYear()
    {
        Assert.True(Leap.IsLeapYear(1996));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy4And5IsStillALeapYear()
    {
        Assert.True(Leap.IsLeapYear(1960));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy100NotDivisibleBy400InCommonYear()
    {
        Assert.False(Leap.IsLeapYear(2100));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy100ButNotBy3IsStillNotALeapYear()
    {
        Assert.False(Leap.IsLeapYear(1900));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy400IsLeapYear()
    {
        Assert.True(Leap.IsLeapYear(2000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy400ButNotBy125IsStillALeapYear()
    {
        Assert.True(Leap.IsLeapYear(2400));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YearDivisibleBy200NotDivisibleBy400InCommonYear()
    {
        Assert.False(Leap.IsLeapYear(1800));
    }
}
