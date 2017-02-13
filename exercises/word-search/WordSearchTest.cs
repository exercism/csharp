using System;
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
        Assert.Equal(new Tuple<int, int>(1, 10), actual.Item1);
        Assert.Equal(new Tuple<int, int>(7, 10), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_horizontal_words_written_right_to_left()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("elixir");
        Assert.Equal(new Tuple<int, int>(6, 5), actual.Item1);
        Assert.Equal(new Tuple<int, int>(1, 5), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_vertical_words_written_top_to_bottom()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("ecmascript");
        Assert.Equal(new Tuple<int, int>(10, 1), actual.Item1);
        Assert.Equal(new Tuple<int, int>(10, 10), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_vertical_words_written_bottom_to_top()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("rust");
        Assert.Equal(new Tuple<int, int>(9, 5), actual.Item1);
        Assert.Equal(new Tuple<int, int>(9, 2), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_diagonal_words_written_top_left_to_bottom_right()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("java");
        Assert.Equal(new Tuple<int, int>(1, 1), actual.Item1);
        Assert.Equal(new Tuple<int, int>(4, 4), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_diagonal_upper_written_bottom_right_to_top_left()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("lua");
        Assert.Equal(new Tuple<int, int>(8, 9), actual.Item1);
        Assert.Equal(new Tuple<int, int>(6, 7), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_diagonal_upper_written_bottom_left_to_top_right()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("lisp");
        Assert.Equal(new Tuple<int, int>(3, 6), actual.Item1);
        Assert.Equal(new Tuple<int, int>(6, 3), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_diagonal_upper_written_top_right_to_bottom_left()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("ruby");
        Assert.Equal(new Tuple<int, int>(8, 6), actual.Item1);
        Assert.Equal(new Tuple<int, int>(5, 9), actual.Item2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_not_find_words_that_are_not_in_the_puzzle()
    {
        var wordSearch = new WordSearch(Puzzle);
        var actual = wordSearch.Find("haskell");
        Assert.Null(actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_be_able_to_search_differently_sized_puzzles()
    {
        const string differentSizePuzzle =
            "qwertyuiopz\n" +
            "luamsicrexe\n" +
            "abcdefghijk";
        var wordSearch = new WordSearch(differentSizePuzzle);

        var actual = wordSearch.Find("exercism");
        Assert.Equal(new Tuple<int, int>(11, 2), actual.Item1);
        Assert.Equal(new Tuple<int, int>(4, 2), actual.Item2);
    }
}