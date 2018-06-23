// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class MinesweeperTest
{
    [Fact]
    public void No_rows()
    {
        var minefield = Array.Empty<string>();
        var expected = Array.Empty<string>();
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_columns()
    {
        var minefield = new string[] 
        { 
            "" 
        };
        var expected = new string[] 
        { 
            "" 
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_mines()
    {
        var minefield = new string[] 
        { 
            "   ",
            "   ",
            "   "
             
        };
        var expected = new string[] 
        { 
            "   ",
            "   ",
            "   "
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Minefield_with_only_mines()
    {
        var minefield = new string[] 
        { 
            "***",
            "***",
            "***"
             
        };
        var expected = new string[] 
        { 
            "***",
            "***",
            "***"
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Mine_surrounded_by_spaces()
    {
        var minefield = new string[] 
        { 
            "   ",
            " * ",
            "   "
             
        };
        var expected = new string[] 
        { 
            "111",
            "1*1",
            "111"
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Space_surrounded_by_mines()
    {
        var minefield = new string[] 
        { 
            "***",
            "* *",
            "***"
             
        };
        var expected = new string[] 
        { 
            "***",
            "*8*",
            "***"
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Horizontal_line()
    {
        var minefield = new string[] 
        { 
            " * * " 
        };
        var expected = new string[] 
        { 
            "1*2*1" 
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Horizontal_line_mines_at_edges()
    {
        var minefield = new string[] 
        { 
            "*   *" 
        };
        var expected = new string[] 
        { 
            "*1 1*" 
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Vertical_line()
    {
        var minefield = new string[] 
        { 
            " ",
            "*",
            " ",
            "*",
            " "
             
        };
        var expected = new string[] 
        { 
            "1",
            "*",
            "2",
            "*",
            "1"
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Vertical_line_mines_at_edges()
    {
        var minefield = new string[] 
        { 
            "*",
            " ",
            " ",
            " ",
            "*"
             
        };
        var expected = new string[] 
        { 
            "*",
            "1",
            " ",
            "1",
            "*"
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cross()
    {
        var minefield = new string[] 
        { 
            "  *  ",
            "  *  ",
            "*****",
            "  *  ",
            "  *  "
             
        };
        var expected = new string[] 
        { 
            " 2*2 ",
            "25*52",
            "*****",
            "25*52",
            " 2*2 "
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }

    [Fact(Skip = "Remove to run test")]
    public void Large_minefield()
    {
        var minefield = new string[] 
        { 
            " *  * ",
            "  *   ",
            "    * ",
            "   * *",
            " *  * ",
            "      "
             
        };
        var expected = new string[] 
        { 
            "1*22*1",
            "12*322",
            " 123*2",
            "112*4*",
            "1*22*2",
            "111111"
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(minefield));
    }
}