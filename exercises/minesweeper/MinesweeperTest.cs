using Xunit;

public class MinesweeperTest
{
    [Fact]
    public void Zero_sized_board()
    {
        var input = "";
        var expected = "";

        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact]
    public void Empty_board()
    {
        var input = FormatInput(new[]
        {
            "   ",
            "   ",
            "   "
        });

        var expected = FormatInput(new[]
        {
            "   ",
            "   ",
            "   "
        });

        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact]
    public void Board_full_of_mines()
    {
        var input = FormatInput(new[]
        {
            "***",
            "***",
            "***"
        });

        var expected = FormatInput(new[]
        {
            "***",
            "***",
            "***"
        });

        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact]
    public void Surrounded()
    {
        var input = FormatInput(new[]
        {
            "***",
            "* *",
            "***"
        });

        var expected = FormatInput(new[]
        {
            "***",
            "*8*",
            "***"
        });

        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact]
    public void Horizontal_line()
    {
        var input = FormatInput(new[]
        {
            " * * "
        });

        var expected = FormatInput(new[]
        {
            "1*2*1"
        });

        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact]
    public void Vertical_line()
    {
        var input = FormatInput(new[]
        {
            " ",
            "*",
            " ",
            "*",
            " "
        });

        var expected = FormatInput(new[]
        {
            "1",
            "*",
            "2",
            "*",
            "1"
        });

        Assert.Equal(expected, Minesweeper.Annotate(input));
    }

    [Fact]
    public void Cross()
    {
        var input = FormatInput(new[]
        {
            "  *  ",
            "  *  ",
            "*****",
            "  *  ",
            "  *  "
        });

        var expected = FormatInput(new[]
        {
            " 2*2 ",
            "25*52",
            "*****",
            "25*52",
            " 2*2 "
        });

        Assert.Equal(expected, Minesweeper.Annotate(input));
    }
    
    private string FormatInput(string[] input)
    {
        return string.Join("\n", input);
    }
}