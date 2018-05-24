// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;
using System;

public class GigasecondTest
{
    [Fact]
    public void Date_only_specification_of_time()
    {
        Assert.Equal(new DateTime(2043, 1, 1, 1, 46, 40), Gigasecond.Add(new DateTime(2011, 4, 25)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_test_for_date_only_specification_of_time()
    {
        Assert.Equal(new DateTime(2009, 2, 19, 1, 46, 40), Gigasecond.Add(new DateTime(1977, 6, 13)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Third_test_for_date_only_specification_of_time()
    {
        Assert.Equal(new DateTime(1991, 3, 27, 1, 46, 40), Gigasecond.Add(new DateTime(1959, 7, 19)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_time_specified()
    {
        Assert.Equal(new DateTime(2046, 10, 2, 23, 46, 40), Gigasecond.Add(new DateTime(2015, 1, 24, 22, 0, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_time_with_day_roll_over()
    {
        Assert.Equal(new DateTime(2046, 10, 3, 1, 46, 39), Gigasecond.Add(new DateTime(2015, 1, 24, 23, 59, 59)));
    }
}