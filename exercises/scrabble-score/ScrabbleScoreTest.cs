using Xunit;

public class ScrabbleScoreTest
{
    [Fact]
    public void Empty_word_scores_zero()
    {
        Assert.Equal(0, Scrabble.Score(""));
    }

    [Fact]
    public void Whitespace_scores_zero()
    {
        Assert.Equal(0, Scrabble.Score(" \t\n"));
    }

    [Fact]
    public void Null_scores_zero()
    {
        Assert.Equal(0, Scrabble.Score(null));
    }

    [Fact]
    public void Scores_very_short_word()
    {
        Assert.Equal(1, Scrabble.Score("a"));
    }

    [Fact]
    public void Scores_other_very_short_word()
    {
        Assert.Equal(4, Scrabble.Score("f"));
    }

    [Fact]
    public void Simple_word_scores_the_number_of_letters()
    {
        Assert.Equal(6, Scrabble.Score("street"));
    }

    [Fact]
    public void Complicated_word_scores_more()
    {
        Assert.Equal(22, Scrabble.Score("quirky"));
    }

    [Fact]
    public void Scores_are_case_insensitive()
    {
        Assert.Equal(41, Scrabble.Score("OXYPHENBUTAZONE"));
    }
    
    [Fact]
    public void Entire_alphabet()
    {
        Assert.Equal(87, Scrabble.Score("abcdefghijklmnopqrstuvwxyz"));
    }
}