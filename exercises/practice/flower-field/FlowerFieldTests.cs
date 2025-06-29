public class FlowerFieldTests
{
    [Fact]
    public void No_rows()
    {
        Assert.Empty(FlowerField.Annotate(Array.Empty<string>()));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_columns()
    {
        string[] garden = [
            ""
        ];
        string[] expected = [
            ""
        ];
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_flowers()
    {
        string[] garden = [
            "   ",
            "   ",
            "   "
        ];
        string[] expected = [
            "   ",
            "   ",
            "   "
        ];
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Garden_full_of_flowers()
    {
        string[] garden = [
            "***",
            "***",
            "***"
        ];
        string[] expected = [
            "***",
            "***",
            "***"
        ];
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Flower_surrounded_by_spaces()
    {
        string[] garden = [
            "   ",
            " * ",
            "   "
        ];
        string[] expected = [
            "111",
            "1*1",
            "111"
        ];
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Space_surrounded_by_flowers()
    {
        string[] garden = [
            "***",
            "* *",
            "***"
        ];
        string[] expected = [
            "***",
            "*8*",
            "***"
        ];
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Horizontal_line()
    {
        string[] garden = [
            " * * "
        ];
        string[] expected = [
            "1*2*1"
        ];
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Horizontal_line_flowers_at_edges()
    {
        string[] garden = [
            "*   *"
        ];
        string[] expected = [
            "*1 1*"
        ];
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Vertical_line()
    {
        string[] garden = [
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
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Vertical_line_flowers_at_edges()
    {
        string[] garden = [
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
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cross()
    {
        string[] garden = [
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
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Large_garden()
    {
        string[] garden = [
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
        Assert.Equal(expected, FlowerField.Annotate(garden));
    }
}
