using Xunit;
using System;
using System.Collections.Generic;
using System.Drawing;

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

    [Fact]
    public void FiveByFiveTerritoryForBlack()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(0, 1));
        Assert.That(result.Item1, Is.EqualTo(GoCounting.Player.Black));
        Assert.That(result.Item2, Is.EquivalentTo(new[] { new Point(0, 0), new Point(0, 1), new Point(1, 0) }));
    }

    [Fact(Skip="Remove to run test")]
    public void FiveByFiveTerritoryForWhite()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(2, 3));
        Assert.That(result.Item1, Is.EqualTo(GoCounting.Player.White));
        Assert.That(result.Item2, Is.EquivalentTo(new[] { new Point(2, 3) }));
    }

    [Fact(Skip="Remove to run test")]
    public void FiveByFiveOpenTerritory()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(1, 4));
        Assert.That(result.Item1, Is.EqualTo(GoCounting.Player.None));
        Assert.That(result.Item2, Is.EquivalentTo(new[] { new Point(0, 3), new Point(0, 4), new Point(1, 4) }));
    }

    [Fact(Skip="Remove to run test")]
    public void FiveByFiveNonTerritoryStone()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.That(board.TerritoryFor(new Point(1, 1)), Is.Null);
    }

    [Fact(Skip="Remove to run test")]
    public void FiveByFiveNonTerritoryDueToTooLowCoordinate()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.That(board.TerritoryFor(new Point(-1, 1)), Is.Null);
    }

    [Fact(Skip="Remove to run test")]
    public void FiveByFiveNonTerritoryDueToTooHighCoordinate()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.That(board.TerritoryFor(new Point(1, 5)), Is.Null);
    }

    [Fact(Skip="Remove to run test")]
    public void MinimalBoardWithNoTerritories()
    {
        var input = "B";
        var board = new GoCounting(input);

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>();

        Assert.That(board.Territories(), Is.EquivalentTo(expected));
    }

    [Fact(Skip="Remove to run test")]
    public void OneTerritoryCoveringTheWholeBoard()
    {
        var input = " ";
        var board = new GoCounting(input);

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>
        {
            [GoCounting.Player.None] = new[] { new Point(0, 0) }
        };

        Assert.That(board.Territories(), Is.EquivalentTo(expected));
    }

    [Fact(Skip="Remove to run test")]
    public void TwoTerritoriesOnRectangularBoard()
    {
        var input = string.Join("\n", new[] { " BW ", " BW " });
        var board = new GoCounting(input);

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>
        {
            [GoCounting.Player.Black] = new[] { new Point(0, 0), new Point(0, 1) },
            [GoCounting.Player.White] = new[] { new Point(3, 0), new Point(3, 1) }
        };

        Assert.That(board.Territories(), Is.EquivalentTo(expected));
    }
}
