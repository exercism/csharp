using System;
using Xunit;

public class RectanglesTests
{
    [Fact]
    public void No_rows()
    {
        string[] rows = Array.Empty<string>();
        Assert.Equal(0, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_columns()
    {
        string[] rows = [
            ""
        ];
        Assert.Equal(0, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_rectangles()
    {
        string[] rows = [
            " "
        ];
        Assert.Equal(0, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_rectangle()
    {
        string[] rows = [
            "+-+",
            "| |",
            "+-+"
        ];
        Assert.Equal(1, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_rectangles_without_shared_parts()
    {
        string[] rows = [
            "  +-+",
            "  | |",
            "+-+-+",
            "| |  ",
            "+-+  "
        ];
        Assert.Equal(2, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Five_rectangles_with_shared_parts()
    {
        string[] rows = [
            "  +-+",
            "  | |",
            "+-+-+",
            "| | |",
            "+-+-+"
        ];
        Assert.Equal(5, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Rectangle_of_height_1_is_counted()
    {
        string[] rows = [
            "+--+",
            "+--+"
        ];
        Assert.Equal(1, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Rectangle_of_width_1_is_counted()
    {
        string[] rows = [
            "++",
            "||",
            "++"
        ];
        Assert.Equal(1, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_by_one_square_is_counted()
    {
        string[] rows = [
            "++",
            "++"
        ];
        Assert.Equal(1, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Only_complete_rectangles_are_counted()
    {
        string[] rows = [
            "  +-+",
            "    |",
            "+-+-+",
            "| | -",
            "+-+-+"
        ];
        Assert.Equal(1, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Rectangles_can_be_of_different_sizes()
    {
        string[] rows = [
            "+------+----+",
            "|      |    |",
            "+---+--+    |",
            "|   |       |",
            "+---+-------+"
        ];
        Assert.Equal(3, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Corner_is_required_for_a_rectangle_to_be_complete()
    {
        string[] rows = [
            "+------+----+",
            "|      |    |",
            "+------+    |",
            "|   |       |",
            "+---+-------+"
        ];
        Assert.Equal(2, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Large_input_with_many_rectangles()
    {
        string[] rows = [
            "+---+--+----+",
            "|   +--+----+",
            "+---+--+    |",
            "|   +--+----+",
            "+---+--+--+-+",
            "+---+--+--+-+",
            "+------+  | |",
            "          +-+"
        ];
        Assert.Equal(60, Rectangles.Count(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Rectangles_must_have_four_sides()
    {
        string[] rows = [
            "+-+ +-+",
            "| | | |",
            "+-+-+-+",
            "  | |  ",
            "+-+-+-+",
            "| | | |",
            "+-+ +-+"
        ];
        Assert.Equal(5, Rectangles.Count(rows));
    }
}
