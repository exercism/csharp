using Xunit;

public class ProverbTest
{
    [Fact]
    public void Line_one()
    {
        Assert.Equal("For want of a nail the shoe was lost.", Proverb.Line(1));
    }

    [Fact]
    public void Line_four()
    {
        Assert.Equal("For want of a rider the message was lost.", Proverb.Line(4));
    }

    [Fact]
    public void Line_seven()
    {
        Assert.Equal("And all for the want of a horseshoe nail.", Proverb.Line(7));
    }

    [Fact]
    public void All_lines()
    {
        const string expected = "For want of a nail the shoe was lost.\n" +
                                "For want of a shoe the horse was lost.\n" +
                                "For want of a horse the rider was lost.\n" +
                                "For want of a rider the message was lost.\n" +
                                "For want of a message the battle was lost.\n" +
                                "For want of a battle the kingdom was lost.\n" +
                                "And all for the want of a horseshoe nail.";

        Assert.Equal(expected, Proverb.AllLines());
    }
}
