using NUnit.Framework;

[TestFixture]
public class MinesweeperTest
{
    [Test]
    public void Zero_sized_board()
    {
        var input = "";
        var expected = "";

        Assert.That(Minesweeper.Annotate(input), Is.EqualTo(expected));
    }

    //[Ignore("Remove to run test")]
    [Test]
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

        Assert.That(Minesweeper.Annotate(input), Is.EqualTo(expected));
    }

    //[Ignore("Remove to run test")]
    [Test]
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

        Assert.That(Minesweeper.Annotate(input), Is.EqualTo(expected));
    }

    //[Ignore("Remove to run test")]
    [Test]
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

        Assert.That(Minesweeper.Annotate(input), Is.EqualTo(expected));
    }

    //[Ignore("Remove to run test")]
    [Test]
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

        Assert.That(Minesweeper.Annotate(input), Is.EqualTo(expected));
    }

    //[Ignore("Remove to run test")]
    [Test]
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

        Assert.That(Minesweeper.Annotate(input), Is.EqualTo(expected));
    }

    //[Ignore("Remove to run test")]
    [Test]
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

        Assert.That(Minesweeper.Annotate(input), Is.EqualTo(expected));
    }
    
    private string FormatInput(string[] input)
    {
        return string.Join("\n", input);
    }
}