using System;
using Xunit;

public class GigasecondTest
{
    [Fact]
    public void First_date()
    {
        var date = Gigasecond.Date(new DateTime(2011, 4, 25, 0, 0, 0, DateTimeKind.Utc));
        Assert.Equal(new DateTime(2043, 1, 1, 1, 46, 40, DateTimeKind.Utc), date);
    }

    [Fact]
    public void Another_date()
    {
        var date = Gigasecond.Date(new DateTime(1977, 6, 13, 0, 0, 0, DateTimeKind.Utc));
        Assert.Equal(new DateTime(2009, 2, 19, 1, 46, 40, DateTimeKind.Utc), date);
    }

    [Fact]
    public void Yet_another_date()
    {
        var date = Gigasecond.Date(new DateTime(1959, 7, 19, 0, 0, 0, DateTimeKind.Utc));
        Assert.Equal(new DateTime(1991, 3, 27, 1, 46, 40, DateTimeKind.Utc), date);
    }
}