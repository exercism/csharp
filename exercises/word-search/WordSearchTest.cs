// This file was auto-generated based on version 1.2.1 of the canonical data.

using System;
using System.Collections.Generic;
using Xunit;

public class WordSearchTest
{
    [Fact]
    public void Should_accept_an_initial_game_grid_and_a_target_search_word()
    {
        var wordsToSearchFor = new[] { "clojure" };
        var grid = "jefblpepre";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = null
        };
        Assert.Null(expected["clojure"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_one_word_written_left_to_right()
    {
        var wordsToSearchFor = new[] { "clojure" };
        var grid = "clojurermt";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 1), (7, 1))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_the_same_word_written_left_to_right_in_a_different_position()
    {
        var wordsToSearchFor = new[] { "clojure" };
        var grid = "mtclojurer";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((3, 1), (9, 1))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_a_different_left_to_right_word()
    {
        var wordsToSearchFor = new[] { "coffee" };
        var grid = "coffeelplx";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["coffee"] = ((1, 1), (6, 1))
        };
        Assert.Equal(expected["coffee"], actual["coffee"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_that_different_left_to_right_word_in_a_different_position()
    {
        var wordsToSearchFor = new[] { "coffee" };
        var grid = "xcoffeezlp";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["coffee"] = ((2, 1), (7, 1))
        };
        Assert.Equal(expected["coffee"], actual["coffee"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_a_left_to_right_word_in_two_line_grid()
    {
        var wordsToSearchFor = new[] { "clojure" };
        var grid = 
            "jefblpepre\n" +
            "tclojurerm";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((2, 2), (8, 2))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_a_left_to_right_word_in_three_line_grid()
    {
        var wordsToSearchFor = new[] { "clojure" };
        var grid = 
            "camdcimgtc\n" +
            "jefblpepre\n" +
            "clojurermt";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 3), (7, 3))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_a_left_to_right_word_in_ten_line_grid()
    {
        var wordsToSearchFor = new[] { "clojure" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_that_left_to_right_word_in_a_different_position_in_a_ten_line_grid()
    {
        var wordsToSearchFor = new[] { "clojure" };
        var grid = 
            "jefblpepre\n" +
            "camdcimgtc\n" +
            "oivokprjsm\n" +
            "pbwasqroua\n" +
            "rixilelhrs\n" +
            "wolcqlirpc\n" +
            "screeaumgr\n" +
            "alxhpburyi\n" +
            "clojurermt\n" +
            "jalaycalmp";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 9), (7, 9))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_a_different_left_to_right_word_in_a_ten_line_grid()
    {
        var wordsToSearchFor = new[] { "fortran" };
        var grid = 
            "jefblpepre\n" +
            "camdcimgtc\n" +
            "oivokprjsm\n" +
            "pbwasqroua\n" +
            "rixilelhrs\n" +
            "wolcqlirpc\n" +
            "fortranftw\n" +
            "alxhpburyi\n" +
            "clojurermt\n" +
            "jalaycalmp";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["fortran"] = ((1, 7), (7, 7))
        };
        Assert.Equal(expected["fortran"], actual["fortran"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_multiple_words()
    {
        var wordsToSearchFor = new[] { "fortran", "clojure" };
        var grid = 
            "jefblpepre\n" +
            "camdcimgtc\n" +
            "oivokprjsm\n" +
            "pbwasqroua\n" +
            "rixilelhrs\n" +
            "wolcqlirpc\n" +
            "fortranftw\n" +
            "alxhpburyi\n" +
            "jalaycalmp\n" +
            "clojurermt";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["fortran"] = ((1, 7), (7, 7))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["fortran"], actual["fortran"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_a_single_word_written_right_to_left()
    {
        var wordsToSearchFor = new[] { "elixir" };
        var grid = "rixilelhrs";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["elixir"] = ((6, 1), (1, 1))
        };
        Assert.Equal(expected["elixir"], actual["elixir"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_multiple_words_written_in_different_horizontal_directions()
    {
        var wordsToSearchFor = new[] { "elixir", "clojure" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_words_written_top_to_bottom()
    {
        var wordsToSearchFor = new[] { "clojure", "elixir", "ecmascript" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5)),
            ["ecmascript"] = ((10, 1), (10, 10))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
        Assert.Equal(expected["ecmascript"], actual["ecmascript"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_words_written_bottom_to_top()
    {
        var wordsToSearchFor = new[] { "clojure", "elixir", "ecmascript", "rust" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5)),
            ["ecmascript"] = ((10, 1), (10, 10)),
            ["rust"] = ((9, 5), (9, 2))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
        Assert.Equal(expected["ecmascript"], actual["ecmascript"]);
        Assert.Equal(expected["rust"], actual["rust"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_words_written_top_left_to_bottom_right()
    {
        var wordsToSearchFor = new[] { "clojure", "elixir", "ecmascript", "rust", "java" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5)),
            ["ecmascript"] = ((10, 1), (10, 10)),
            ["rust"] = ((9, 5), (9, 2)),
            ["java"] = ((1, 1), (4, 4))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
        Assert.Equal(expected["ecmascript"], actual["ecmascript"]);
        Assert.Equal(expected["rust"], actual["rust"]);
        Assert.Equal(expected["java"], actual["java"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_words_written_bottom_right_to_top_left()
    {
        var wordsToSearchFor = new[] { "clojure", "elixir", "ecmascript", "rust", "java", "lua" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5)),
            ["ecmascript"] = ((10, 1), (10, 10)),
            ["rust"] = ((9, 5), (9, 2)),
            ["java"] = ((1, 1), (4, 4)),
            ["lua"] = ((8, 9), (6, 7))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
        Assert.Equal(expected["ecmascript"], actual["ecmascript"]);
        Assert.Equal(expected["rust"], actual["rust"]);
        Assert.Equal(expected["java"], actual["java"]);
        Assert.Equal(expected["lua"], actual["lua"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_words_written_bottom_left_to_top_right()
    {
        var wordsToSearchFor = new[] { "clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5)),
            ["ecmascript"] = ((10, 1), (10, 10)),
            ["rust"] = ((9, 5), (9, 2)),
            ["java"] = ((1, 1), (4, 4)),
            ["lua"] = ((8, 9), (6, 7)),
            ["lisp"] = ((3, 6), (6, 3))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
        Assert.Equal(expected["ecmascript"], actual["ecmascript"]);
        Assert.Equal(expected["rust"], actual["rust"]);
        Assert.Equal(expected["java"], actual["java"]);
        Assert.Equal(expected["lua"], actual["lua"]);
        Assert.Equal(expected["lisp"], actual["lisp"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_locate_words_written_top_right_to_bottom_left()
    {
        var wordsToSearchFor = new[] { "clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5)),
            ["ecmascript"] = ((10, 1), (10, 10)),
            ["rust"] = ((9, 5), (9, 2)),
            ["java"] = ((1, 1), (4, 4)),
            ["lua"] = ((8, 9), (6, 7)),
            ["lisp"] = ((3, 6), (6, 3)),
            ["ruby"] = ((8, 6), (5, 9))
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
        Assert.Equal(expected["ecmascript"], actual["ecmascript"]);
        Assert.Equal(expected["rust"], actual["rust"]);
        Assert.Equal(expected["java"], actual["java"]);
        Assert.Equal(expected["lua"], actual["lua"]);
        Assert.Equal(expected["lisp"], actual["lisp"]);
        Assert.Equal(expected["ruby"], actual["ruby"]);
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_fail_to_locate_a_word_that_is_not_in_the_puzzle()
    {
        var wordsToSearchFor = new[] { "clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby", "haskell" };
        var grid = 
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
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        var expected = new Dictionary<string, ((int, int), (int, int))?>
        {
            ["clojure"] = ((1, 10), (7, 10)),
            ["elixir"] = ((6, 5), (1, 5)),
            ["ecmascript"] = ((10, 1), (10, 10)),
            ["rust"] = ((9, 5), (9, 2)),
            ["java"] = ((1, 1), (4, 4)),
            ["lua"] = ((8, 9), (6, 7)),
            ["lisp"] = ((3, 6), (6, 3)),
            ["ruby"] = ((8, 6), (5, 9)),
            ["haskell"] = null
        };
        Assert.Equal(expected["clojure"], actual["clojure"]);
        Assert.Equal(expected["elixir"], actual["elixir"]);
        Assert.Equal(expected["ecmascript"], actual["ecmascript"]);
        Assert.Equal(expected["rust"], actual["rust"]);
        Assert.Equal(expected["java"], actual["java"]);
        Assert.Equal(expected["lua"], actual["lua"]);
        Assert.Equal(expected["lisp"], actual["lisp"]);
        Assert.Equal(expected["ruby"], actual["ruby"]);
        Assert.Null(expected["haskell"]);
    }
}