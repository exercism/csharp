using NUnit.Framework;

[TestFixture]
public class ClockTest
{
    [Test]
    [TestCase(8, "08:00")]
    [TestCase(9, "09:00")]
    public void PrintsTheHour(int hours, string expected)
    {
        Assert.That(new Clock(hours).ToString(), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(11, 9, "11:09")]
    [TestCase(11, 19, "11:19")]
    public void PrintsPastTheHour(int hours, int minutes, string expected)
    {
        Assert.That(new Clock(hours, minutes).ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void CanAddMinutes()
    {
        var clock = new Clock(10).Add(3);
        Assert.That(clock.ToString(), Is.EqualTo("10:03"));
    }

    [Test]
    public void CanAddOverAnHour()
    {
        var clock = new Clock(10).Add(63);
        Assert.That(clock.ToString(), Is.EqualTo("11:03"));
    }

    [Test]
    public void CanSubtractMinutes()
    {
        var clock = new Clock(10, 3).Subtract(3);
        Assert.That(clock.ToString(), Is.EqualTo("10:00"));
    }

    [Test]
    public void CanSubtractToPreviousHour()
    {
        var clock = new Clock(10, 3).Subtract(30);
        Assert.That(clock.ToString(), Is.EqualTo("09:33"));
    }

    [Test]
    public void CanSubtractOverAnHour()
    {
        var clock = new Clock(10, 3).Subtract(70);
        Assert.That(clock.ToString(), Is.EqualTo("08:53"));
    }

    [Test]
    public void WrapsAroundMidnight()
    {
        var clock = new Clock(23, 59).Add(2);
        Assert.That(clock.ToString(), Is.EqualTo("00:01"));
    }

    [Test]
    public void WrapsAroundMidnightBackwards()
    {
        var clock = new Clock(0, 1).Subtract(2);
        Assert.That(clock.ToString(), Is.EqualTo("23:59"));
    }

    [Test]
    public void MidnightIsZeroHundredHours()
    {
        var clock = new Clock(24);
        Assert.That(clock.ToString(), Is.EqualTo("00:00"));
    }

    [Test]
    public void SixtyMinutesIsNextHour()
    {
        var clock = new Clock(1, 60);
        Assert.That(clock.ToString(), Is.EqualTo("02:00"));
    }
}