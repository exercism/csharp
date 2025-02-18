using Xunit;

public class WordSearchTests
{
    [Fact]
    public void Should_accept_an_initial_game_grid_and_a_target_search_word()
    {
        string[] wordsToSearchFor = ["clojure"];
        var grid =
            "jefblpepre";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Null(actual["clojure"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_one_word_written_left_to_right()
    {
        string[] wordsToSearchFor = ["clojure"];
        var grid =
            "clojurermt";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Equal(((1, 1), (7, 1)), actual["clojure"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_the_same_word_written_left_to_right_in_a_different_position()
    {
        string[] wordsToSearchFor = ["clojure"];
        var grid =
            "mtclojurer";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Equal(((3, 1), (9, 1)), actual["clojure"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_a_different_left_to_right_word()
    {
        string[] wordsToSearchFor = ["coffee"];
        var grid =
            "coffeelplx";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Equal(((1, 1), (6, 1)), actual["coffee"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_that_different_left_to_right_word_in_a_different_position()
    {
        string[] wordsToSearchFor = ["coffee"];
        var grid =
            "xcoffeezlp";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Equal(((2, 1), (7, 1)), actual["coffee"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_a_left_to_right_word_in_two_line_grid()
    {
        string[] wordsToSearchFor = ["clojure"];
        var grid =
            "jefblpepre\n" +
            "tclojurerm";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Equal(((2, 2), (8, 2)), actual["clojure"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_a_left_to_right_word_in_three_line_grid()
    {
        string[] wordsToSearchFor = ["clojure"];
        var grid =
            "camdcimgtc\n" +
            "jefblpepre\n" +
            "clojurermt";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Equal(((1, 3), (7, 3)), actual["clojure"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_a_left_to_right_word_in_ten_line_grid()
    {
        string[] wordsToSearchFor = ["clojure"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_that_left_to_right_word_in_a_different_position_in_a_ten_line_grid()
    {
        string[] wordsToSearchFor = ["clojure"];
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
        Assert.Equal(((1, 9), (7, 9)), actual["clojure"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_a_different_left_to_right_word_in_a_ten_line_grid()
    {
        string[] wordsToSearchFor = ["fortran"];
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
        Assert.Equal(((1, 7), (7, 7)), actual["fortran"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_multiple_words()
    {
        string[] wordsToSearchFor = ["fortran", "clojure"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((1, 7), (7, 7)), actual["fortran"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_a_single_word_written_right_to_left()
    {
        string[] wordsToSearchFor = ["elixir"];
        var grid =
            "rixilelhrs";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Equal(((6, 1), (1, 1)), actual["elixir"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_multiple_words_written_in_different_horizontal_directions()
    {
        string[] wordsToSearchFor = ["elixir", "clojure"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_words_written_top_to_bottom()
    {
        string[] wordsToSearchFor = ["clojure", "elixir", "ecmascript"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
        Assert.Equal(((10, 1), (10, 10)), actual["ecmascript"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_words_written_bottom_to_top()
    {
        string[] wordsToSearchFor = ["clojure", "elixir", "ecmascript", "rust"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
        Assert.Equal(((10, 1), (10, 10)), actual["ecmascript"]);
        Assert.Equal(((9, 5), (9, 2)), actual["rust"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_words_written_top_left_to_bottom_right()
    {
        string[] wordsToSearchFor = ["clojure", "elixir", "ecmascript", "rust", "java"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
        Assert.Equal(((10, 1), (10, 10)), actual["ecmascript"]);
        Assert.Equal(((9, 5), (9, 2)), actual["rust"]);
        Assert.Equal(((1, 1), (4, 4)), actual["java"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_words_written_bottom_right_to_top_left()
    {
        string[] wordsToSearchFor = ["clojure", "elixir", "ecmascript", "rust", "java", "lua"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
        Assert.Equal(((10, 1), (10, 10)), actual["ecmascript"]);
        Assert.Equal(((9, 5), (9, 2)), actual["rust"]);
        Assert.Equal(((1, 1), (4, 4)), actual["java"]);
        Assert.Equal(((8, 9), (6, 7)), actual["lua"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_words_written_bottom_left_to_top_right()
    {
        string[] wordsToSearchFor = ["clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
        Assert.Equal(((10, 1), (10, 10)), actual["ecmascript"]);
        Assert.Equal(((9, 5), (9, 2)), actual["rust"]);
        Assert.Equal(((1, 1), (4, 4)), actual["java"]);
        Assert.Equal(((8, 9), (6, 7)), actual["lua"]);
        Assert.Equal(((3, 6), (6, 3)), actual["lisp"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_locate_words_written_top_right_to_bottom_left()
    {
        string[] wordsToSearchFor = ["clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
        Assert.Equal(((10, 1), (10, 10)), actual["ecmascript"]);
        Assert.Equal(((9, 5), (9, 2)), actual["rust"]);
        Assert.Equal(((1, 1), (4, 4)), actual["java"]);
        Assert.Equal(((8, 9), (6, 7)), actual["lua"]);
        Assert.Equal(((3, 6), (6, 3)), actual["lisp"]);
        Assert.Equal(((8, 6), (5, 9)), actual["ruby"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_fail_to_locate_a_word_that_is_not_in_the_puzzle()
    {
        string[] wordsToSearchFor = ["clojure", "elixir", "ecmascript", "rust", "java", "lua", "lisp", "ruby", "haskell"];
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
        Assert.Equal(((1, 10), (7, 10)), actual["clojure"]);
        Assert.Equal(((6, 5), (1, 5)), actual["elixir"]);
        Assert.Equal(((10, 1), (10, 10)), actual["ecmascript"]);
        Assert.Equal(((9, 5), (9, 2)), actual["rust"]);
        Assert.Equal(((1, 1), (4, 4)), actual["java"]);
        Assert.Equal(((8, 9), (6, 7)), actual["lua"]);
        Assert.Equal(((3, 6), (6, 3)), actual["lisp"]);
        Assert.Equal(((8, 6), (5, 9)), actual["ruby"]);
        Assert.Null(actual["haskell"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_fail_to_locate_words_that_are_not_on_horizontal_vertical_or_diagonal_lines()
    {
        string[] wordsToSearchFor = ["aef", "ced", "abf", "cbd"];
        var grid =
            "abc\n" +
            "def";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Null(actual["aef"]);

        Assert.Null(actual["ced"]);

        Assert.Null(actual["abf"]);

        Assert.Null(actual["cbd"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_not_concatenate_different_lines_to_find_a_horizontal_word()
    {
        string[] wordsToSearchFor = ["elixir"];
        var grid =
            "abceli\n" +
            "xirdfg";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Null(actual["elixir"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_not_wrap_around_horizontally_to_find_a_word()
    {
        string[] wordsToSearchFor = ["lisp"];
        var grid =
            "silabcdefp";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Null(actual["lisp"]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Should_not_wrap_around_vertically_to_find_a_word()
    {
        string[] wordsToSearchFor = ["rust"];
        var grid =
            "s\n" +
            "u\n" +
            "r\n" +
            "a\n" +
            "b\n" +
            "c\n" +
            "t";
        var sut = new WordSearch(grid);
        var actual = sut.Search(wordsToSearchFor);
        Assert.Null(actual["rust"]);
    }
}
