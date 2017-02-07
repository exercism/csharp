using Xunit;

public class ClockTest
{
    [Theory]
    [InlineData(8, "08:00")]
    [InlineData(9, "09:00")]
    public void Prints_the_hour(int hours, string expected)
    {
        Assert.Equal(expected, new Clock(hours).ToString());
    }

    [Theory(Skip="Remove to run test")]
    [InlineData(11, 9, "11:09")]
    [InlineData(11, 19, "11:19")]
    public void Prints_past_the_hour(int hours, int minutes, string expected)
    {
        Assert.Equal(expected, new Clock(hours, minutes).ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Can_add_minutes()
    {
        var clock = new Clock(10).Add(3);
        Assert.Equal("10:03", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Can_add_over_an_hour()
    {
        var clock = new Clock(10).Add(63);
        Assert.Equal("11:03", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Can_add_over_more_than_one_day()
    {
        var clock = new Clock(10).Add(7224);
        Assert.Equal("10:24", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Can_subtract_minutes()
    {
        var clock = new Clock(10, 3).Subtract(3);
        Assert.Equal("10:00", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Can_subtract_to_previous_hour()
    {
        var clock = new Clock(10, 3).Subtract(30);
        Assert.Equal("09:33", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Can_subtract_over_an_hour()
    {
        var clock = new Clock(10, 3).Subtract(70);
        Assert.Equal("08:53", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Wraps_around_midnight()
    {
        var clock = new Clock(23, 59).Add(2);
        Assert.Equal("00:01", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Wraps_around_midnight_backwards()
    {
        var clock = new Clock(0, 1).Subtract(2);
        Assert.Equal("23:59", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Midnight_is_zero_hundred_hours()
    {
        var clock = new Clock(24);
        Assert.Equal("00:00", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Sixty_minutes_is_next_hour()
    {
        var clock = new Clock(1, 60);
        Assert.Equal("02:00", clock.ToString());
    }

    [Fact(Skip="Remove to run test")]
    public void Clocks_with_same_time_are_equal()
    {
        var clock1 = new Clock(14, 30);
        var clock2 = new Clock(14, 30);
        Assert.Equal(clock2, clock1);
    }

    [Fact(Skip="Remove to run test")]
    public void Clocks_with_different_time_are_not_equal()
    {
        var clock1 = new Clock(15, 30);
        var clock2 = new Clock(14, 30);
        Assert.NotEqual(clock2, clock1);
    }

    [Fact(Skip="Remove to run test")]
    public void Overflown_clocks_with_same_time_are_equal()
    {
        var clock1 = new Clock(14, 30);
        var clock2 = new Clock(38, 30);
        Assert.Equal(clock2, clock1);
    }
}