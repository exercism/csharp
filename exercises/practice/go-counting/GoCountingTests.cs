public class GoCountingTests
{
    [Fact]
    public void Black_corner_territory_on_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (0, 1);
        var (territoryOwner, territoryCoordinates) = sut.Territory(coordinate);
        var expectedOwner = Owner.Black;
        var expectedCoordinates = new HashSet<(int, int)> { (0, 0), (0, 1), (1, 0) };
        Assert.Equal(expectedOwner, territoryOwner);
        Assert.Equal(expectedCoordinates, territoryCoordinates.ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void White_center_territory_on_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (2, 3);
        var (territoryOwner, territoryCoordinates) = sut.Territory(coordinate);
        var expectedOwner = Owner.White;
        var expectedCoordinates = new HashSet<(int, int)> { (2, 3) };
        Assert.Equal(expectedOwner, territoryOwner);
        Assert.Equal(expectedCoordinates, territoryCoordinates.ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Open_corner_territory_on_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (1, 4);
        var (territoryOwner, territoryCoordinates) = sut.Territory(coordinate);
        var expectedOwner = Owner.None;
        var expectedCoordinates = new HashSet<(int, int)> { (0, 3), (0, 4), (1, 4) };
        Assert.Equal(expectedOwner, territoryOwner);
        Assert.Equal(expectedCoordinates, territoryCoordinates.ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_stone_and_not_a_territory_on_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (1, 1);
        var (territoryOwner, territoryCoordinates) = sut.Territory(coordinate);
        var expectedOwner = Owner.None;
        var expectedCoordinates = new HashSet<(int, int)>();
        Assert.Equal(expectedOwner, territoryOwner);
        Assert.Equal(expectedCoordinates, territoryCoordinates.ToHashSet());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_because_x_is_too_low_for_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (-1, 1);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_because_x_is_too_high_for_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (5, 1);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_because_y_is_too_low_for_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (1, -1);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_because_y_is_too_high_for_5x5_board()
    {
        var board =
            "  B  \n" +
            " B B \n" +
            "B W B\n" +
            " W W \n" +
            "  W  ";
        var sut = new GoCounting(board);
        var coordinate = (1, 5);
        Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_territory_is_the_whole_board()
    {
        var board =
            " ";
        var sut = new GoCounting(board);
        var actual = sut.Territories();
        var expected = new Dictionary<Owner, HashSet<(int, int)>>
        {
            [Owner.Black] = new HashSet<(int, int)>() { },
            [Owner.White] = new HashSet<(int, int)>() { },
            [Owner.None] = new HashSet<(int, int)>() { (0, 0) }
        };
        Assert.Equal(expected[Owner.Black], actual[Owner.Black]);
        Assert.Equal(expected[Owner.White], actual[Owner.White]);
        Assert.Equal(expected[Owner.None], actual[Owner.None]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_territory_rectangular_board()
    {
        var board =
            " BW \n" +
            " BW ";
        var sut = new GoCounting(board);
        var actual = sut.Territories();
        var expected = new Dictionary<Owner, HashSet<(int, int)>>
        {
            [Owner.Black] = new HashSet<(int, int)>() { (0, 0), (0, 1) },
            [Owner.White] = new HashSet<(int, int)>() { (3, 0), (3, 1) },
            [Owner.None] = new HashSet<(int, int)>() { }
        };
        Assert.Equal(expected[Owner.Black], actual[Owner.Black]);
        Assert.Equal(expected[Owner.White], actual[Owner.White]);
        Assert.Equal(expected[Owner.None], actual[Owner.None]);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_region_rectangular_board()
    {
        var board =
            " B ";
        var sut = new GoCounting(board);
        var actual = sut.Territories();
        var expected = new Dictionary<Owner, HashSet<(int, int)>>
        {
            [Owner.Black] = new HashSet<(int, int)>() { (0, 0), (2, 0) },
            [Owner.White] = new HashSet<(int, int)>() { },
            [Owner.None] = new HashSet<(int, int)>() { }
        };
        Assert.Equal(expected[Owner.Black], actual[Owner.Black]);
        Assert.Equal(expected[Owner.White], actual[Owner.White]);
        Assert.Equal(expected[Owner.None], actual[Owner.None]);
    }
}
