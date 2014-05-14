using System;
using NUnit.Framework;

[TestFixture]
public class GigasecondTest
{
    [Test]
    public void First_date()
    {
        var gs = new Gigasecond(new DateTime(2011, 4, 25));
        Assert.That(gs.Date(), Is.EqualTo(new DateTime(2043, 1, 1)));
    }

    [Test]
    public void Another_date()
    {
        var gs = new Gigasecond(new DateTime(1977, 6, 13));
        Assert.That(gs.Date(), Is.EqualTo(new DateTime(2009, 2, 19)));
    }

    [Test]
    public void Yet_another_date()
    {
        var gs = new Gigasecond(new DateTime(1959, 7, 19));
        Assert.That(gs.Date(), Is.EqualTo(new DateTime(1991, 3, 27)));
    }
}