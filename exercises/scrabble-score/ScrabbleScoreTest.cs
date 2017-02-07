using Xunit;

public class ScrabbleScoreTest
{
    [Fact]
    public void Empty_word_scores_zero()
    {
        Assert.That(Scrabble.Score(""), Is.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void Whitespace_scores_zero()
    {
        Assert.That(Scrabble.Score(" \t\n"), Is.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void Null_scores_zero()
    {
        Assert.That(Scrabble.Score(null), Is.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void Scores_very_short_word()
    {
        Assert.That(Scrabble.Score("a"), Is.EqualTo(1));
    }

    [Fact(Skip="Remove to run test")]
    public void Scores_other_very_short_word()
    {
        Assert.That(Scrabble.Score("f"), Is.EqualTo(4));
    }

    [Fact(Skip="Remove to run test")]
    public void Simple_word_scores_the_number_of_letters()
    {
        Assert.That(Scrabble.Score("street"), Is.EqualTo(6));
    }

    [Fact(Skip="Remove to run test")]
    public void Complicated_word_scores_more()
    {
        Assert.That(Scrabble.Score("quirky"), Is.EqualTo(22));
    }

    [Fact(Skip="Remove to run test")]
    public void Scores_are_case_insensitive()
    {
        Assert.That(Scrabble.Score("OXYPHENBUTAZONE"), Is.EqualTo(41));
    }
    
    [Fact(Skip="Remove to run test")]
    public void Entire_alphabet()
    {
        Assert.That(Scrabble.Score("abcdefghijklmnopqrstuvwxyz"), Is.EqualTo(87));
    }
}