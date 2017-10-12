// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class MinesweeperTest
{
    [Fact]
    public void No_rows()
    {
        var input = new string[] 
        { 
             
        };
        var expected = new string[] 
        { 
             
        };
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_columns()
    {
        var input = new string[] 
        { 
            "" 
        };
        var expected = new string[] 
        { 
            "" 
        };
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_mines()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Board_with_only_mines()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Mine_surrounded_by_spaces()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Space_surrounded_by_mines()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Horizontal_line()
    {
        var input = new string[] 
        { 
            " * * " 
        };
        var expected = new string[] 
        { 
            "1*2*1" 
        };
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Horizontal_line_mines_at_edges()
    {
        var input = new string[] 
        { 
            "*   *" 
        };
        var expected = new string[] 
        { 
            "*1 1*" 
        };
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Vertical_line()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Vertical_line_mines_at_edges()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cross()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Large_board()
    {
        var input = new string[] 
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
        Assert.Equal(expected, Minesweeper.Annotate(input));
    }
}