using NUnit.Framework;

public class ProverbTest
{
    [Test]
    public void Line_one()
    {
        Assert.That(Proverb.Line(1), Is.EqualTo("For want of a nail the shoe was lost."));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Line_four()
    {
        Assert.That(Proverb.Line(4), Is.EqualTo("For want of a rider the message was lost."));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Line_seven()
    {
        Assert.That(Proverb.Line(7), Is.EqualTo("And all for the want of a horseshoe nail."));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void All_lines()
    {
        const string expected = "For want of a nail the shoe was lost.\n" +
                                "For want of a shoe the horse was lost.\n" +
                                "For want of a horse the rider was lost.\n" +
                                "For want of a rider the message was lost.\n" +
                                "For want of a message the battle was lost.\n" +
                                "For want of a battle the kingdom was lost.\n" +
                                "And all for the want of a horseshoe nail.";

        Assert.That(Proverb.AllLines(), Is.EqualTo(expected));
    }
}
