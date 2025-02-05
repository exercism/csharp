using System;
using Xunit;

public class MinesweeperTests
{
    [Fact]
    public void No_rows()
    {
        Assert.Empty(Minesweeper.Annotate(Array.Empty<string>()));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_columns()
    {
        string[] minefield = [
            ""
        ];
        string[] expected = [
            ""
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_mines()
    {
        string[] minefield = [
            "   ",
            "   ",
            "   "
        ];
        string[] expected = [
            "   ",
            "   ",
            "   "
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Minefield_with_only_mines()
    {
        string[] minefield = [
            "***",
            "***",
            "***"
        ];
        string[] expected = [
            "***",
            "***",
            "***"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Mine_surrounded_by_spaces()
    {
        string[] minefield = [
            "   ",
            " * ",
            "   "
        ];
        string[] expected = [
            "111",
            "1*1",
            "111"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Space_surrounded_by_mines()
    {
        string[] minefield = [
            "***",
            "* *",
            "***"
        ];
        string[] expected = [
            "***",
            "*8*",
            "***"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Horizontal_line()
    {
        string[] minefield = [
            " * * "
        ];
        string[] expected = [
            "1*2*1"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Horizontal_line_mines_at_edges()
    {
        string[] minefield = [
            "*   *"
        ];
        string[] expected = [
            "*1 1*"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Vertical_line()
    {
        string[] minefield = [
            " ",
            "*",
            " ",
            "*",
            " "
        ];
        string[] expected = [
            "1",
            "*",
            "2",
            "*",
            "1"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Vertical_line_mines_at_edges()
    {
        string[] minefield = [
            "*",
            " ",
            " ",
            " ",
            "*"
        ];
        string[] expected = [
            "*",
            "1",
            " ",
            "1",
            "*"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cross()
    {
        string[] minefield = [
            "  *  ",
            "  *  ",
            "*****",
            "  *  ",
            "  *  "
        ];
        string[] expected = [
            " 2*2 ",
            "25*52",
            "*****",
            "25*52",
            " 2*2 "
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Large_minefield()
    {
        string[] minefield = [
            " *  * ",
            "  *   ",
            "    * ",
            "   * *",
            " *  * ",
            "      "
        ];
        string[] expected = [
            "1*22*1",
            "12*322",
            " 123*2",
            "112*4*",
            "1*22*2",
            "111111"
        ];
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }
}
