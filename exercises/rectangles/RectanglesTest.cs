using Xunit;

public class RectanglesTest
{
    [Fact]
    public void No_rows()
    {
        var input = new string[0];
        Assert.Equal(0, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void No_columns()
    {
        var input = new[] { "" };
        Assert.Equal(0, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void No_rectangles()
    {
        var input = new[] { " " };
        Assert.Equal(0, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void One_rectangle()
    {
        var input = new[]
        {
            "+-+",
            "| |",
            "+-+"
        };
        Assert.Equal(1, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void Two_rectangles_without_shared_parts()
    {
        var input = new[]
        {
            "  +-+",
            "  | |",
            "+-+-+",
            "| |  ",
            "+-+  "
        };
        Assert.Equal(2, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void Five_rectangles_with_shared_parts()
    {
        var input = new[]
        {
            "  +-+",
            "  | |",
            "+-+-+",
            "| | |",
            "+-+-+"
        };
        Assert.Equal(5, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void Only_complete_rectangles_are_counted()
    {
        var input = new[]
        {
            "  +-+",
            "    |",
            "+-+-+",
            "| | -",
            "+-+-+"
        };
        Assert.Equal(1, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void Rectangles_can_be_of_different_sizes()
    {
        var input = new[]
        {
            "+------+----+",
            "|      |    |",
            "+---+--+    |",
            "|   |       |",
            "+---+-------+"
        };
        Assert.Equal(3, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void Corner_is_required_for_a_rectangle_to_be_complete()
    {
        var input = new[]
        {
            "+------+----+",
            "|      |    |",
            "+------+    |",
            "|   |       |",
            "+---+-------+"
        };
        Assert.Equal(2, Rectangles.Count(input));
    }

    [Fact(Skip="Remove to run test")]
    public void Large_input_with_many_rectangles()
    {
        var input = new[]
        {
            "+---+--+----+",
            "|   +--+----+",
            "+---+--+    |",
            "|   +--+----+",
            "+---+--+--+-+",
            "+---+--+--+-+",
            "+------+  | |",
            "          +-+"
        };
        Assert.Equal(60, Rectangles.Count(input));
    }
}