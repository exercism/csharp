// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class RectanglesTest
{
    [Fact]
    public void No_rows()
    {
        var strings = Array.Empty<string>();
        Assert.Equal(0, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_columns()
    {
        var strings = new[]
        {
            ""
        };
        Assert.Equal(0, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_rectangles()
    {
        var strings = new[]
        {
            " "
        };
        Assert.Equal(0, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_rectangle()
    {
        var strings = new[]
        {
            "+-+",
            "| |",
            "+-+"
        };
        Assert.Equal(1, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_rectangles_without_shared_parts()
    {
        var strings = new[]
        {
            "  +-+",
            "  | |",
            "+-+-+",
            "| |  ",
            "+-+  "
        };
        Assert.Equal(2, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Five_rectangles_with_shared_parts()
    {
        var strings = new[]
        {
            "  +-+",
            "  | |",
            "+-+-+",
            "| | |",
            "+-+-+"
        };
        Assert.Equal(5, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rectangle_of_height_1_is_counted()
    {
        var strings = new[]
        {
            "+--+",
            "+--+"
        };
        Assert.Equal(1, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rectangle_of_width_1_is_counted()
    {
        var strings = new[]
        {
            "++",
            "||",
            "++"
        };
        Assert.Equal(1, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_1x1_square_is_counted()
    {
        var strings = new[]
        {
            "++",
            "++"
        };
        Assert.Equal(1, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Only_complete_rectangles_are_counted()
    {
        var strings = new[]
        {
            "  +-+",
            "    |",
            "+-+-+",
            "| | -",
            "+-+-+"
        };
        Assert.Equal(1, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rectangles_can_be_of_different_sizes()
    {
        var strings = new[]
        {
            "+------+----+",
            "|      |    |",
            "+---+--+    |",
            "|   |       |",
            "+---+-------+"
        };
        Assert.Equal(3, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Corner_is_required_for_a_rectangle_to_be_complete()
    {
        var strings = new[]
        {
            "+------+----+",
            "|      |    |",
            "+------+    |",
            "|   |       |",
            "+---+-------+"
        };
        Assert.Equal(2, Rectangles.Count(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Large_input_with_many_rectangles()
    {
        var strings = new[]
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
        Assert.Equal(60, Rectangles.Count(strings));
    }
}