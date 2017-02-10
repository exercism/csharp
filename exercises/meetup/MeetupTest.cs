using System;
using Xunit;

public class MeetupTest
{
    [InlineData(5, DayOfWeek.Monday, "2013-5-13")]
    [InlineData(3, DayOfWeek.Tuesday, "2013-3-19")]
    [InlineData(1, DayOfWeek.Wednesday, "2013-1-16")]
    [InlineData(5, DayOfWeek.Thursday, "2013-5-16")]
    [InlineData(4, DayOfWeek.Friday, "2013-4-19")]
    [InlineData(2, DayOfWeek.Saturday, "2013-2-16")]
    [InlineData(10, DayOfWeek.Sunday, "2013-10-13")]
    public void Finds_first_teenth_day_of_week_in_a_month(int month, DayOfWeek dayOfWeek, string expected)
    {
        DateTime day = new Meetup(month, 2013).Day(dayOfWeek, Schedule.Teenth);
        Assert.Equal(expected, day.ToString("yyyy-M-d"));
    }

    [Theory]
    [InlineData(3, DayOfWeek.Monday, "2013-3-4")]
    [InlineData(5, DayOfWeek.Tuesday, "2013-5-7")]
    [InlineData(7, DayOfWeek.Wednesday, "2013-7-3")]
    [InlineData(9, DayOfWeek.Thursday, "2013-9-5")]
    [InlineData(11, DayOfWeek.Friday, "2013-11-1")]
    [InlineData(1, DayOfWeek.Saturday, "2013-1-5")]
    [InlineData(4, DayOfWeek.Sunday, "2013-4-7")]
    public void Finds_first_day_of_week_in_a_month(int month, DayOfWeek dayOfWeek, string expected)
    {
        DateTime day = new Meetup(month, 2013).Day(dayOfWeek, Schedule.First);
        Assert.Equal(expected, day.ToString("yyyy-M-d"));
    }

    [Theory]
    [InlineData(3, DayOfWeek.Monday, "2013-3-11")]
    [InlineData(5, DayOfWeek.Tuesday, "2013-5-14")]
    [InlineData(7, DayOfWeek.Wednesday, "2013-7-10")]
    [InlineData(9, DayOfWeek.Thursday, "2013-9-12")]
    [InlineData(12, DayOfWeek.Friday, "2013-12-13")]
    [InlineData(2, DayOfWeek.Saturday, "2013-2-9")]
    [InlineData(4, DayOfWeek.Sunday, "2013-4-14")]
    public void Finds_second_day_of_week_in_a_month(int month, DayOfWeek dayOfWeek, string expected)
    {
        DateTime day = new Meetup(month, 2013).Day(dayOfWeek, Schedule.Second);
        Assert.Equal(expected, day.ToString("yyyy-M-d"));
    }

    [Theory]
    [InlineData(3, DayOfWeek.Monday, "2013-3-18")]
    [InlineData(5, DayOfWeek.Tuesday, "2013-5-21")]
    [InlineData(7, DayOfWeek.Wednesday, "2013-7-17")]
    [InlineData(9, DayOfWeek.Thursday, "2013-9-19")]
    [InlineData(12, DayOfWeek.Friday, "2013-12-20")]
    [InlineData(2, DayOfWeek.Saturday, "2013-2-16")]
    [InlineData(4, DayOfWeek.Sunday, "2013-4-21")]
    public void Finds_third_day_of_week_in_a_month(int month, DayOfWeek dayOfWeek, string expected)
    {
        DateTime day = new Meetup(month, 2013).Day(dayOfWeek, Schedule.Third);
        Assert.Equal(expected, day.ToString("yyyy-M-d"));
    }

    [Theory]
    [InlineData(3, DayOfWeek.Monday, "2013-3-25")]
    [InlineData(5, DayOfWeek.Tuesday, "2013-5-28")]
    [InlineData(7, DayOfWeek.Wednesday, "2013-7-24")]
    [InlineData(9, DayOfWeek.Thursday, "2013-9-26")]
    [InlineData(12, DayOfWeek.Friday, "2013-12-27")]
    [InlineData(2, DayOfWeek.Saturday, "2013-2-23")]
    [InlineData(4, DayOfWeek.Sunday, "2013-4-28")]
    public void Finds_fourth_day_of_week_in_a_month(int month, DayOfWeek dayOfWeek, string expected)
    {
        DateTime day = new Meetup(month, 2013).Day(dayOfWeek, Schedule.Fourth);
        Assert.Equal(expected, day.ToString("yyyy-M-d"));
    }

    [Theory]
    [InlineData(3, DayOfWeek.Monday, "2013-3-25")]
    [InlineData(5, DayOfWeek.Tuesday, "2013-5-28")]
    [InlineData(7, DayOfWeek.Wednesday, "2013-7-31")]
    [InlineData(9, DayOfWeek.Thursday, "2013-9-26")]
    [InlineData(12, DayOfWeek.Friday, "2013-12-27")]
    [InlineData(2, DayOfWeek.Saturday, "2013-2-23")]
    [InlineData(3, DayOfWeek.Sunday, "2013-3-31")]
    public void Finds_last_day_of_week_in_a_month(int month, DayOfWeek dayOfWeek, string expected)
    {
        DateTime day = new Meetup(month, 2013).Day(dayOfWeek, Schedule.Last);
        Assert.Equal(expected, day.ToString("yyyy-M-d"));
    }
}