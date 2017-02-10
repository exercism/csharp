﻿using Xunit;
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

    [Fact]
    public void FiveByFiveTerritoryForBlack()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(0, 1));
        Assert.Equal(GoCounting.Player.Black, result.Item1);
        Assert.Equal(new[] { new Point(0, 0), new Point(0, 1), new Point(1, 0) }.AsEnumerable(), result.Item2.AsEnumerable());
    }

    [Fact]
    public void FiveByFiveTerritoryForWhite()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(2, 3));
        Assert.Equal(GoCounting.Player.White, result.Item1);
        Assert.Equal(new[] { new Point(2, 3) }.AsEnumerable(), result.Item2.AsEnumerable());
    }

    [Fact]
    public void FiveByFiveOpenTerritory()
    {
        var board = new GoCounting(boardFiveByFive);
        var result = board.TerritoryFor(new Point(1, 4));
        Assert.Equal(GoCounting.Player.None, result.Item1);
        Assert.Equal(new[] { new Point(0, 3), new Point(0, 4), new Point(1, 4) }.AsEnumerable(), result.Item2);
    }

    [Fact]
    public void FiveByFiveNonTerritoryStone()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.Null(board.TerritoryFor(new Point(1, 1)));
    }

    [Fact]
    public void FiveByFiveNonTerritoryDueToTooLowCoordinate()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.Null(board.TerritoryFor(new Point(-1, 1)));
    }

    [Fact]
    public void FiveByFiveNonTerritoryDueToTooHighCoordinate()
    {
        var board = new GoCounting(boardFiveByFive);
        Assert.Null(board.TerritoryFor(new Point(1, 5)));
    }

    [Fact]
    public void MinimalBoardWithNoTerritories()
    {
        var input = "B";
        var board = new GoCounting(input);

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>();

        Assert.Equal(expected, board.Territories());
    }

    [Fact]
    public void OneTerritoryCoveringTheWholeBoard()
    {
        var input = " ";
        var board = new GoCounting(input);

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>
        {
            [GoCounting.Player.None] = new[] { new Point(0, 0) }.AsEnumerable()
        };

        Assert.Equal(expected, board.Territories());
    }

    [Fact]
    public void TwoTerritoriesOnRectangularBoard()
    {
        var input = string.Join("\n", new[] { " BW ", " BW " });
        var board = new GoCounting(input);

        var expected = new Dictionary<GoCounting.Player, IEnumerable<Point>>
        {
            [GoCounting.Player.Black] = new[] { new Point(0, 0), new Point(0, 1) }.AsEnumerable(),
            [GoCounting.Player.White] = new[] { new Point(3, 0), new Point(3, 1) }.AsEnumerable()
        };

        Assert.Equal(expected, board.Territories());
    }
}
