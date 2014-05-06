using NUnit.Framework;

[TestFixture]
public class LeapTest
{
    [Test]
    public void ValidLeapYear()
    {
        Assert.That(Year.IsLeap(1996), Is.True);
    }

    [Test, Ignore]
    public void InvalidLeapYear()
    {
        Assert.That(Year.IsLeap(1997), Is.False);
    }

    [Test, Ignore]
    public void TurnOfThe20thCenturyIsNotALeapYear()
    {
        Assert.That(Year.IsLeap(1900), Is.False);
    }

    [Test, Ignore]
    public void TurnOfThe25thCenturyIsALeapYear()
    {
        Assert.That(Year.IsLeap(2400), Is.True);
    }
}