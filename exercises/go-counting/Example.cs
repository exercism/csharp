using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

public class GoCounting
{
    public enum Player
    {
        None,
        Black,
        White
    }

    private readonly Player[][] board;

    public GoCounting(string input)
    {
        board = ParseBoard(input);
    }

    private static Player CharToPlayer(char c)
    {
        switch (c)
        {
            case 'B': return Player.Black;
            case 'W': return Player.White;
            default: return Player.None;
        }
    }

    private static Player[][] ParseBoard(string input)
    {
        var split = input.Split('\n');
        var rows = split.Length;
        var cols = split[0].Length;

        return split.Select(row => row.Select(CharToPlayer).ToArray()).ToArray();
    }

    private int Cols => board[0].Length;
    private int Rows => board.Length;

    private bool IsValidCoordinate(Point coordinate) =>
        coordinate.Y >= 0 && coordinate.Y < Rows &&
        coordinate.X >= 0 && coordinate.X < Cols;

    private Player GetPlayer(Point coordinate) => board[coordinate.Y][coordinate.X];

    private bool isEmpty(Point coordinate) => GetPlayer(coordinate) == Player.None;
    private bool isTaken(Point coordinate) => !isEmpty(coordinate);

    private IEnumerable<Point> EmptyCoordinates()
    {
        return Enumerable.Range(0, Cols).SelectMany(col =>
               Enumerable.Range(0, Rows).Select(row => new Point(col, row)))
                .Where(isEmpty);
    }

    private IEnumerable<Point> NeighborCoordinates(Point coordinate)
    {
        var row = coordinate.Y;
        var col = coordinate.X;

        var coords = new[]
        {
            new Point(col, row - 1),
            new Point(col-1, row),
            new Point(col+1, row),
            new Point(col, row+1)
        };

        return coords.Where(IsValidCoordinate);
    }

    private IEnumerable<Point> NonEmptyNeighborCoordinates(Point coordinate) =>
        NeighborCoordinates(coordinate).Where(neighborCoordinate => !isEmpty(neighborCoordinate));

    private IEnumerable<Point> EmptyNeighborCoordinates(Point coordinate) =>
        NeighborCoordinates(coordinate).Where(isEmpty);

    private Player TerritoryOwner(HashSet<Point> coords)
    {
        var neighborColors = coords.SelectMany(NonEmptyNeighborCoordinates).Where(isTaken).Select(GetPlayer);
        var uniqueNeighborColors = ToSet(neighborColors);

        if (uniqueNeighborColors.Count == 1)
            return uniqueNeighborColors.First();

        return Player.None;
    }

    private HashSet<Point> TerritoryHelper(HashSet<Point> remainder, HashSet<Point> acc)
    {
        if (!remainder.Any())
            return acc;

        var emptyNeighbors = new HashSet<Point>(remainder.SelectMany(EmptyNeighborCoordinates));
        emptyNeighbors.ExceptWith(acc);

        var newAcc = ToSet(acc);
        newAcc.UnionWith(emptyNeighbors);
        return TerritoryHelper(emptyNeighbors, newAcc);
    }

    private HashSet<Point> Territory(Point coordinate) =>
        IsValidCoordinate(coordinate) && isEmpty(coordinate)
            ? TerritoryHelper(ToSingletonSet(coordinate), ToSingletonSet(coordinate))
            : new HashSet<Point>();

    public Tuple<Player, IEnumerable<Point>> TerritoryFor(Point coord)
    {
        var coords = Territory(coord);
        if (!coords.Any())
            return null;

        var owner = TerritoryOwner(coords);
        return Tuple.Create(owner, coords.AsEnumerable());
    }

    private Dictionary<Player, IEnumerable<Point>> TerritoriesHelper(HashSet<Point> remainder, Dictionary<Player, IEnumerable<Point>> acc)
    {
        if (!remainder.Any())
            return acc;

        var coord = remainder.First();
        var coords = Territory(coord);
        var owner = TerritoryOwner(coords);

        var newRemainder = ToSet(remainder);
        newRemainder.ExceptWith(coords);

        var newAcc = new Dictionary<Player, IEnumerable<Point>>(acc);
        newAcc[owner] = coords;

        return TerritoriesHelper(newRemainder, newAcc);
    }

    public Dictionary<Player, IEnumerable<Point>> Territories()
    {
        var emptyCoords = EmptyCoordinates();
        return TerritoriesHelper(ToSet(emptyCoords), new Dictionary<Player, IEnumerable<Point>>());
    }

    private static HashSet<T> ToSet<T>(IEnumerable<T> value) => new HashSet<T>(value);
    private static HashSet<T> ToSingletonSet<T>(T value) => new HashSet<T> { value };    
}

