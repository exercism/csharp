using Xunit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class GoCountingTest
{
    private static readonly string boardFiveByFive =
        string.Join("\n", new[]
            {
                "  B  ",
                " B B ",
                "B W B",
                " W W ",
                "  W  "
            });

    private static readonly string board9x9 =
        string.Join("\n", new[]
            {
                "  B   B  ",
                "B   B   B",
                "WBBBWBBBW",
                "W W W W W",
                "         ",
                " W W W W ",
                "B B   B B",
                " W BBB W ",
                "   B B   "
            });

    [Fact(Skip = "Remove to run test")]
    public void FiveByFiveTerritoryForBlack()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(0, 1));
        var expected = new HashSet<Point> { new Point(0, 0), new Point(0, 1), new Point(1, 0) };
        Assert.Equal(GoCounting.Player.Black, result.Item1);        
        Assert.True(expected.SetEquals(result.Item2));
    }

    [Fact(Skip = "Remove to run test")]
    public void FiveByFiveTerritoryForWhite()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(2, 3));
        var expected = new HashSet<Point> { new Point(2, 3) };
        Assert.Equal(GoCounting.Player.White, result.Item1);
        Assert.True(expected.SetEquals(result.Item2));
    }

    [Fact(Skip = "Remove to run test")]
    public void FiveByFiveOpenTerritory()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(1, 4));
        var expected = new HashSet<Point> { new Point(0, 3), new Point(0, 4), new Point(1, 4) };
        Assert.Equal(GoCounting.Player.None, result.Item1);
        Assert.True(expected.SetEquals(result.Item2));
    }

    [Fact(Skip = "Remove to run test")]
    public void FiveByFiveNonTerritoryStone()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.Null(board.TerritoryFor(new Point(1, 1)));
    }

    [Fact(Skip = "Remove to run test")]
    public void FiveByFiveNonTerritoryDueToTooLowCoordinate()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.Null(board.TerritoryFor(new Point(-1, 1)));
    }

    [Fact(Skip = "Remove to run test")]
    public void FiveByFiveNonTerritoryDueToTooHighCoordinate()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.Null(board.TerritoryFor(new Point(1, 5)));
    }

    [Fact(Skip = "Remove to run test")]
    public void MinimalBoardWithNoTerritories()
    {
        var input = "B";
        var board = new GoCounting(input);

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>();

        Assert.Equal(expected, board.Territories());
    }

    [Fact(Skip = "Remove to run test")]
    public void OneTerritoryCoveringTheWholeBoard()
    {
        var input = " ";
        var board = new GoCounting(input);
        var actual = board.Territories();

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>
        {
            [GoCounting.Player.None] = new[] { new Point(0, 0) }
        };
        
        Assert.Equal(expected.Keys, actual.Keys);
        Assert.Equal(expected[GoCounting.Player.None], actual[GoCounting.Player.None]);
    }

    [Fact(Skip = "Remove to run test")]
    public void TwoTerritoriesOnRectangularBoard()
    {
        var input = string.Join("\n", new[] { " BW ", " BW " });
        var board = new GoCounting(input);
        var actual = board.Territories();

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>
        {
            [GoCounting.Player.Black] = new[] { new Point(0, 0), new Point(0, 1) },
            [GoCounting.Player.White] = new[] { new Point(3, 0), new Point(3, 1) }
        };
                
        Assert.Equal(expected.Keys, actual.Keys);
        Assert.Equal(expected[GoCounting.Player.Black], actual[GoCounting.Player.Black]);
        Assert.Equal(expected[GoCounting.Player.White], actual[GoCounting.Player.White]);
    }

    private class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public static readonly EnumerableEqualityComparer<T> Instance = new EnumerableEqualityComparer<T>();

        public bool Equals(IEnumerable<T> x, IEnumerable<T> y) => x.SequenceEqual(y);

        public int GetHashCode(IEnumerable<T> obj)
        {
            throw new NotImplementedException();
        }
    }
}
