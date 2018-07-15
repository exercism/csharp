// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class MeetupTest
{
    [Fact]
    public void Monteenth_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Monteenth_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Monteenth_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tuesteenth_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tuesteenth_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tuesteenth_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Wednesteenth_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = new DateTime(2013, 1, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Wednesteenth_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = new DateTime(2013, 2, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Wednesteenth_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Thursteenth_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Thursteenth_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Thursteenth_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Friteenth_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Friteenth_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Friteenth_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Saturteenth_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = new DateTime(2013, 2, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Saturteenth_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Saturteenth_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = new DateTime(2013, 10, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sunteenth_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sunteenth_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sunteenth_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = new DateTime(2013, 10, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Teenth));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 4);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 1);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 7);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 4);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = new DateTime(2013, 7, 3);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 7);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 5);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = new DateTime(2013, 10, 3);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = new DateTime(2013, 11, 1);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = new DateTime(2013, 12, 6);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = new DateTime(2013, 1, 5);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = new DateTime(2013, 2, 2);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 3);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 7);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.First));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 11);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 8);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 14);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 11);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = new DateTime(2013, 7, 10);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 14);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 12);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = new DateTime(2013, 10, 10);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = new DateTime(2013, 11, 8);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = new DateTime(2013, 12, 13);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = new DateTime(2013, 1, 12);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = new DateTime(2013, 2, 9);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 10);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 14);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Second));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 18);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 15);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 21);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 18);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = new DateTime(2013, 7, 17);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 21);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = new DateTime(2013, 10, 17);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = new DateTime(2013, 11, 15);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = new DateTime(2013, 12, 20);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = new DateTime(2013, 1, 19);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = new DateTime(2013, 2, 16);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 17);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 21);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Third));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 25);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 22);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 28);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 25);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = new DateTime(2013, 7, 24);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 28);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 26);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = new DateTime(2013, 10, 24);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = new DateTime(2013, 11, 22);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = new DateTime(2013, 12, 27);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = new DateTime(2013, 1, 26);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = new DateTime(2013, 2, 23);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 24);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Fourth_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 28);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Fourth));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_monday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 25);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_monday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 29);
        Assert.Equal(expected, sut.Day(DayOfWeek.Monday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_tuesday_of_may_2013()
    {
        var sut = new Meetup(5, 2013);
        var expected = new DateTime(2013, 5, 28);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_tuesday_of_june_2013()
    {
        var sut = new Meetup(6, 2013);
        var expected = new DateTime(2013, 6, 25);
        Assert.Equal(expected, sut.Day(DayOfWeek.Tuesday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_july_2013()
    {
        var sut = new Meetup(7, 2013);
        var expected = new DateTime(2013, 7, 31);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_august_2013()
    {
        var sut = new Meetup(8, 2013);
        var expected = new DateTime(2013, 8, 28);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_thursday_of_september_2013()
    {
        var sut = new Meetup(9, 2013);
        var expected = new DateTime(2013, 9, 26);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_thursday_of_october_2013()
    {
        var sut = new Meetup(10, 2013);
        var expected = new DateTime(2013, 10, 31);
        Assert.Equal(expected, sut.Day(DayOfWeek.Thursday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_friday_of_november_2013()
    {
        var sut = new Meetup(11, 2013);
        var expected = new DateTime(2013, 11, 29);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_friday_of_december_2013()
    {
        var sut = new Meetup(12, 2013);
        var expected = new DateTime(2013, 12, 27);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_saturday_of_january_2013()
    {
        var sut = new Meetup(1, 2013);
        var expected = new DateTime(2013, 1, 26);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_saturday_of_february_2013()
    {
        var sut = new Meetup(2, 2013);
        var expected = new DateTime(2013, 2, 23);
        Assert.Equal(expected, sut.Day(DayOfWeek.Saturday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_sunday_of_march_2013()
    {
        var sut = new Meetup(3, 2013);
        var expected = new DateTime(2013, 3, 31);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_sunday_of_april_2013()
    {
        var sut = new Meetup(4, 2013);
        var expected = new DateTime(2013, 4, 28);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_february_2012()
    {
        var sut = new Meetup(2, 2012);
        var expected = new DateTime(2012, 2, 29);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_wednesday_of_december_2014()
    {
        var sut = new Meetup(12, 2014);
        var expected = new DateTime(2014, 12, 31);
        Assert.Equal(expected, sut.Day(DayOfWeek.Wednesday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void Last_sunday_of_february_2015()
    {
        var sut = new Meetup(2, 2015);
        var expected = new DateTime(2015, 2, 22);
        Assert.Equal(expected, sut.Day(DayOfWeek.Sunday, Schedule.Last));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_friday_of_december_2012()
    {
        var sut = new Meetup(12, 2012);
        var expected = new DateTime(2012, 12, 7);
        Assert.Equal(expected, sut.Day(DayOfWeek.Friday, Schedule.First));
    }
}