using System;
using System.Collections.Generic;
using System.Linq;

public enum GoPlayer
{
    None,
    Black,
    White
}

public class GoCounting
{
    private readonly GoPlayer[][] board;

    public GoCounting(string input)
    {
        board = ParseBoard(input);
    }

    private static GoPlayer CharToPlayer(char c)
    {
        switch (c)
        {
            case 'B': return GoPlayer.Black;
            case 'W': return GoPlayer.White;
            default: return GoPlayer.None;
        }
    }

    private static GoPlayer[][] ParseBoard(string input)
    {
        var split = input.Split('\n');
        var rows = split.Length;
        var cols = split[0].Length;

        return split.Select(row => row.Select(CharToPlayer).ToArray()).ToArray();
    }

    private int Cols => board[0].Length;
    private int Rows => board.Length;

    private bool IsValidCoordinate(Tuple<int, int> coordinate) =>
        coordinate.Item2 >= 0 && coordinate.Item2 < Rows &&
        coordinate.Item1 >= 0 && coordinate.Item1 < Cols;

    private GoPlayer GetPlayer(Tuple<int, int> coordinate) => board[coordinate.Item2][coordinate.Item1];

    private bool IsEmpty(Tuple<int, int> coordinate) => GetPlayer(coordinate) == GoPlayer.None;
    private bool IsTaken(Tuple<int, int> coordinate) => !IsEmpty(coordinate);

    private IEnumerable<Tuple<int, int>> EmptyCoordinates()
    {
        return Enumerable.Range(0, Cols).SelectMany(col =>
               Enumerable.Range(0, Rows).Select(row => new Tuple<int, int>(col, row)))
                .Where(IsEmpty);
    }

    private IEnumerable<Tuple<int, int>> NeighborCoordinates(Tuple<int, int> coordinate)
    {
        var row = coordinate.Item2;
        var col = coordinate.Item1;

        var coords = new[]
        {
            new Tuple<int, int>(col,   row - 1),
            new Tuple<int, int>(col-1, row),
            new Tuple<int, int>(col+1, row),
            new Tuple<int, int>(col,   row+1)
        };

        return coords.Where(IsValidCoordinate);
    }

    private IEnumerable<Tuple<int, int>> TakenNeighborCoordinates(Tuple<int, int> coordinate) =>
        NeighborCoordinates(coordinate).Where(IsTaken);

    private IEnumerable<Tuple<int, int>> EmptyNeighborCoordinates(Tuple<int, int> coordinate) =>
        NeighborCoordinates(coordinate).Where(IsEmpty);

    private GoPlayer TerritoryOwner(HashSet<Tuple<int, int>> coords)
    {
        var neighborColors = coords.SelectMany(TakenNeighborCoordinates).Select(GetPlayer);
        var uniqueNeighborColors = ToSet(neighborColors);

        if (uniqueNeighborColors.Count == 1)
            return uniqueNeighborColors.First();

        return GoPlayer.None;
    }

    private HashSet<Tuple<int, int>> TerritoryHelper(HashSet<Tuple<int, int>> remainder, HashSet<Tuple<int, int>> acc)
    {
        if (!remainder.Any())
            return acc;

        var emptyNeighbors = new HashSet<Tuple<int, int>>(remainder.SelectMany(EmptyNeighborCoordinates));
        emptyNeighbors.ExceptWith(acc);

        var newAcc = ToSet(acc);
        newAcc.UnionWith(emptyNeighbors);
        return TerritoryHelper(emptyNeighbors, newAcc);
    }

    private HashSet<Tuple<int, int>> Territory(Tuple<int, int> coordinate) =>
        IsValidCoordinate(coordinate) && IsEmpty(coordinate)
            ? TerritoryHelper(ToSingletonSet(coordinate), ToSingletonSet(coordinate))
            : new HashSet<Tuple<int, int>>();

    public Tuple<GoPlayer, IEnumerable<Tuple<int, int>>> TerritoryFor(Tuple<int, int> coord)
    {
        var coords = Territory(coord);
        if (!coords.Any())
            return null;

        var owner = TerritoryOwner(coords);
        return Tuple.Create(owner, coords.AsEnumerable());
    }

    private Dictionary<GoPlayer, IEnumerable<Tuple<int, int>>> TerritoriesHelper(HashSet<Tuple<int, int>> remainder, Dictionary<GoPlayer, IEnumerable<Tuple<int, int>>> acc)
    {
        if (!remainder.Any())
            return acc;

        var coord = remainder.First();
        var coords = Territory(coord);
        var owner = TerritoryOwner(coords);

        var newRemainder = ToSet(remainder);
        newRemainder.ExceptWith(coords);

        var newAcc = new Dictionary<GoPlayer, IEnumerable<Tuple<int, int>>>(acc)
        {
            [owner] = coords
        };
        return TerritoriesHelper(newRemainder, newAcc);
    }

    public Dictionary<GoPlayer, IEnumerable<Tuple<int, int>>> Territories()
    {
        var emptyCoords = EmptyCoordinates();
        return TerritoriesHelper(ToSet(emptyCoords), new Dictionary<GoPlayer, IEnumerable<Tuple<int, int>>>());
    }

    private static HashSet<T> ToSet<T>(IEnumerable<T> value) => new HashSet<T>(value);
    private static HashSet<T> ToSingletonSet<T>(T value) => new HashSet<T> { value };    
}