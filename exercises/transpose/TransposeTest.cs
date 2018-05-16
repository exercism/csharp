// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class TransposeTest
{
    [Fact]
    public void Empty_string()
    {
        var lines = "";
        var expected = "";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_characters_in_a_row()
    {
        var lines = "A1";
        var expected = 
            "A\n" +
            "1";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_characters_in_a_column()
    {
        var lines = 
            "A\n" +
            "1";
        var expected = "A1";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Simple()
    {
        var lines = 
            "ABC\n" +
            "123";
        var expected = 
            "A1\n" +
            "B2\n" +
            "C3";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Single_line()
    {
        var lines = "Single line.";
        var expected = 
            "S\n" +
            "i\n" +
            "n\n" +
            "g\n" +
            "l\n" +
            "e\n" +
            " \n" +
            "l\n" +
            "i\n" +
            "n\n" +
            "e\n" +
            ".";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void First_line_longer_than_second_line()
    {
        var lines = 
            "The fourth line.\n" +
            "The fifth line.";
        var expected = 
            "TT\n" +
            "hh\n" +
            "ee\n" +
            "  \n" +
            "ff\n" +
            "oi\n" +
            "uf\n" +
            "rt\n" +
            "th\n" +
            "h \n" +
            " l\n" +
            "li\n" +
            "in\n" +
            "ne\n" +
            "e.\n" +
            ".";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Second_line_longer_than_first_line()
    {
        var lines = 
            "The first line.\n" +
            "The second line.";
        var expected = 
            "TT\n" +
            "hh\n" +
            "ee\n" +
            "  \n" +
            "fs\n" +
            "ie\n" +
            "rc\n" +
            "so\n" +
            "tn\n" +
            " d\n" +
            "l \n" +
            "il\n" +
            "ni\n" +
            "en\n" +
            ".e\n" +
            " .";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Mixed_line_length()
    {
        var lines = 
            "The longest line.\n" +
            "A long line.\n" +
            "A longer line.\n" +
            "A line.";
        var expected = 
            "TAAA\n" +
            "h   \n" +
            "elll\n" +
            " ooi\n" +
            "lnnn\n" +
            "ogge\n" +
            "n e.\n" +
            "glr\n" +
            "ei \n" +
            "snl\n" +
            "tei\n" +
            " .n\n" +
            "l e\n" +
            "i .\n" +
            "n\n" +
            "e\n" +
            ".";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Square()
    {
        var lines = 
            "HEART\n" +
            "EMBER\n" +
            "ABUSE\n" +
            "RESIN\n" +
            "TREND";
        var expected = 
            "HEART\n" +
            "EMBER\n" +
            "ABUSE\n" +
            "RESIN\n" +
            "TREND";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rectangle()
    {
        var lines = 
            "FRACTURE\n" +
            "OUTLINED\n" +
            "BLOOMING\n" +
            "SEPTETTE";
        var expected = 
            "FOBS\n" +
            "RULE\n" +
            "ATOP\n" +
            "CLOT\n" +
            "TIME\n" +
            "UNIT\n" +
            "RENT\n" +
            "EDGE";
        Assert.Equal(expected, Transpose.String(lines));
    }

    [Fact(Skip = "Remove to run test")]
    public void Triangle()
    {
        var lines = 
            "T\n" +
            "EE\n" +
            "AAA\n" +
            "SSSS\n" +
            "EEEEE\n" +
            "RRRRRR";
        var expected = 
            "TEASER\n" +
            " EASER\n" +
            "  ASER\n" +
            "   SER\n" +
            "    ER\n" +
            "     R";
        Assert.Equal(expected, Transpose.String(lines));
    }
}