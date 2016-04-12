using NUnit.Framework;

[TestFixture]
public class ClockTest
{
    [TestCase(8, "08:00")]
    [TestCase(9, "09:00")]
    public void Prints_the_hour(int hours, string expected)
    {
        Assert.That(new Clock(hours).ToString(), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [TestCase(11, 9, "11:09")]
    [TestCase(11, 19, "11:19")]
    public void Prints_past_the_hour(int hours, int minutes, string expected)
    {
        Assert.That(new Clock(hours, minutes).ToString(), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_minutes()
    {
        var clock = new Clock(10).Add(3);
        Assert.That(clock.ToString(), Is.EqualTo("10:03"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_over_an_hour()
    {
        var clock = new Clock(10).Add(63);
        Assert.That(clock.ToString(), Is.EqualTo("11:03"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_over_more_than_one_day()
    {
        var clock = new Clock(10).Add(7224);
        Assert.That(clock.ToString(), Is.EqualTo("10:24"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_subtract_minutes()
    {
        var clock = new Clock(10, 3).Subtract(3);
        Assert.That(clock.ToString(), Is.EqualTo("10:00"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_subtract_to_previous_hour()
    {
        var clock = new Clock(10, 3).Subtract(30);
        Assert.That(clock.ToString(), Is.EqualTo("09:33"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_subtract_over_an_hour()
    {
        var clock = new Clock(10, 3).Subtract(70);
        Assert.That(clock.ToString(), Is.EqualTo("08:53"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Wraps_around_midnight()
    {
        var clock = new Clock(23, 59).Add(2);
        Assert.That(clock.ToString(), Is.EqualTo("00:01"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Wraps_around_midnight_backwards()
    {
        var clock = new Clock(0, 1).Subtract(2);
        Assert.That(clock.ToString(), Is.EqualTo("23:59"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Midnight_is_zero_hundred_hours()
    {
        var clock = new Clock(24);
        Assert.That(clock.ToString(), Is.EqualTo("00:00"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Sixty_minutes_is_next_hour()
    {
        var clock = new Clock(1, 60);
        Assert.That(clock.ToString(), Is.EqualTo("02:00"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Clocks_with_same_time_are_equal()
    {
        var clock1 = new Clock(14, 30);
        var clock2 = new Clock(14, 30);
        Assert.That(clock1, Is.EqualTo(clock2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Overflown_clocks_with_same_time_are_equal()
    {
        var clock1 = new Clock(14, 30);
        var clock2 = new Clock(38, 30);
        Assert.That(clock1, Is.EqualTo(clock2));
    }
}