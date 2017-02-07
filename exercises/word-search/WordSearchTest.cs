using System;
using System.Drawing;
using Xunit;

public class WordSearchTest
{
    private const string Puzzle =
        "jefblpepre\n" +
        "camdcimgtc\n" +
        "oivokprjsm\n" +
        "pbwasqroua\n" +
        "rixilelhrs\n" +
        "wolcqlirpc\n" +
        "screeaumgr\n" +
        "alxhpburyi\n" +
        "jalaycalmp\n" +
        "clojurermt";

    [Fact]
    public void Should_find_horizontal_words_written_left_to_right()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("clojure");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(1, 10), new Point(7, 10))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_find_horizontal_words_written_right_to_left()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("elixir");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(6, 5), new Point(1, 5))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_find_vertical_words_written_top_to_bottom()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("ecmascript");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(10, 1), new Point(10, 10))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_find_vertical_words_written_bottom_to_top()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("rust");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(9, 5), new Point(9, 2))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_find_diagonal_words_written_top_left_to_bottom_right()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("java");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(1, 1), new Point(4, 4))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_find_diagonal_upper_written_bottom_right_to_top_left()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("lua");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(8, 9), new Point(6, 7))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_find_diagonal_upper_written_bottom_left_to_top_right()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("lisp");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(3, 6), new Point(6, 3))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_find_diagonal_upper_written_top_right_to_bottom_left()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("ruby");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(8, 6), new Point(5, 9))));
    }

    [Fact(Skip="Remove to run test")]
    public void Should_not_find_words_that_are_not_in_the_puzzle()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("haskell");
        Assert.That(actual, Is.Null);
    }

    [Fact(Skip="Remove to run test")]
    public void Should_be_able_to_search_differently_sized_puzzles()
    {
        const string differentSizePuzzle =
            "qwertyuiopz\n" +
            "luamsicrexe\n" +
            "abcdefghijk";
        var wordSearch = new WordSearch(differentSizePuzzle);

        var actual = wordSearch.Find("exercism");
        Assert.That(actual, Is.EqualTo(Tuple.Create(new Point(11, 2), new Point(4, 2))));
    }
}