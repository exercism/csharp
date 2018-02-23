// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;
using System;

public class MeetupTest
{
    [Fact]
    public void Monteenth_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Monteenth_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Monteenth_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tuesteenth_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tuesteenth_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tuesteenth_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Wednesteenth_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = "2013-01-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Wednesteenth_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = "2013-02-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Wednesteenth_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Thursteenth_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Thursteenth_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Thursteenth_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Friteenth_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Friteenth_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Friteenth_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Saturteenth_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = "2013-02-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Saturteenth_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Saturteenth_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = "2013-10-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sunteenth_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sunteenth_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sunteenth_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = "2013-10-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-04";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-01";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-07";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-04";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = "2013-07-03";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-07";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-05";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = "2013-10-03";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = "2013-11-01";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = "2013-12-06";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = "2013-01-05";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = "2013-02-02";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-03";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-07";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-11";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-08";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-14";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-11";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = "2013-07-10";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-14";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-12";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = "2013-10-10";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = "2013-11-08";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = "2013-12-13";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = "2013-01-12";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = "2013-02-09";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-10";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-14";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-18";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-15";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-21";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-18";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = "2013-07-17";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-21";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = "2013-10-17";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = "2013-11-15";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = "2013-12-20";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = "2013-01-19";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = "2013-02-16";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-17";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-21";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-25";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-22";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-28";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-25";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = "2013-07-24";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-28";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-26";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = "2013-10-24";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = "2013-11-22";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = "2013-12-27";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = "2013-01-26";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = "2013-02-23";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-24";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-28";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-25";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-29";
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = "2013-05-28";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = "2013-06-25";
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = "2013-07-31";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = "2013-08-28";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = "2013-09-26";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = "2013-10-31";
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = "2013-11-29";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = "2013-12-27";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = "2013-01-26";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = "2013-02-23";
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = "2013-03-31";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = "2013-04-28";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_february_2012()
    {
        var sut = new Meetup(2, 2012);
        var expected = "2012-02-29";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_december_2014()
    {
        var sut = new Meetup(12, 2014);
        var expected = "2014-12-31";
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_sunday_of_february_2015()
    {
        var sut = new Meetup(2, 2015);
        var expected = "2015-02-22";
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last).ToString("yyyy-MM-dd"));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_friday_of_december_2012()
    {
        var sut = new Meetup(12, 2012);
        var expected = "2012-12-07";
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First).ToString("yyyy-MM-dd"));
    }
}