using NUnit.Framework;

public class RectanglesTest
{
    [Test]
    public void No_rows()
    {
        var input = new string[0];
        Assert.That(Rectangles.Count(input), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void No_columns()
    {
        var input = new[] { "" };
        Assert.That(Rectangles.Count(input), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void No_rectangles()
    {
        var input = new[] { " " };
        Assert.That(Rectangles.Count(input), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void One_rectangle()
    {
        var input = new[]
        {
            "+-+",
            "| |",
            "+-+"
        };
        Assert.That(Rectangles.Count(input), Is.EqualTo(1));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(Rectangles.Count(input), Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(Rectangles.Count(input), Is.EqualTo(5));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(Rectangles.Count(input), Is.EqualTo(1));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(Rectangles.Count(input), Is.EqualTo(3));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(Rectangles.Count(input), Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(Rectangles.Count(input), Is.EqualTo(60));
    }
}