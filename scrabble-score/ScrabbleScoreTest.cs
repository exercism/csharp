using NUnit.Framework;

[TestFixture]
public class ScrabbleScoreTest
{
    [Test]
    public void Empty_word_scores_zero()
    {
        Assert.That(new Scrabble("").Score(), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void Whitespace_scores_zero()
    {
        Assert.That(new Scrabble(" \t\n").Score(), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void Null_scores_zero()
    {
        Assert.That(new Scrabble(null).Score(), Is.EqualTo(0));
    }

    [Ignore]
    [Test]
    public void Scores_very_short_word()
    {
        Assert.That(new Scrabble("a").Score(), Is.EqualTo(1));
    }

    [Ignore]
    [Test]
    public void Scores_other_very_short_word()
    {
        Assert.That(new Scrabble("f").Score(), Is.EqualTo(4));
    }

    [Ignore]
    [Test]
    public void Simple_word_scores_the_number_of_letters()
    {
        Assert.That(new Scrabble("street").Score(), Is.EqualTo(6));
    }

    [Ignore]
    [Test]
    public void Complicated_word_scores_more()
    {
        Assert.That(new Scrabble("quirky").Score(), Is.EqualTo(22));
    }

    [Ignore]
    [Test]
    public void Scores_are_case_insensitive()
    {
        Assert.That(new Scrabble("MULTIBILLIONAIRE").Score(), Is.EqualTo(20));
    }

    [Ignore]
    [Test]
    public void Convenient_scoring()
    {
        Assert.That(Scrabble.Score("alacrity"), Is.EqualTo(13));
    }
}