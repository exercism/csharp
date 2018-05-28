using System;
using System.Collections.Generic;
using System.Linq;

public enum Owner
{
    None,
    Black,
    White
}

public class GoCounting
{
    private readonly Owner[][] board;

    public GoCounting(string input)
    {
        board = ParseBoard(input);
    }

    private static Owner CharToPlayer(char c)
    {
        switch (c)
        {
            case 'B': return Owner.Black;
            case 'W': return Owner.White;
            default: return Owner.None;
        }
    }

    private static Owner[][] ParseBoard(string input)
    {
        var split = input.Split('\n');
        return split.Select(row => row.Select(CharToPlayer).ToArray()).ToArray();
    }

    private int Cols => board[0].Length;
    private int Rows => board.Length;

    private bool IsValidCoordinate(ValueTuple<int, int> coordinate) =>
        coordinate.Item2 >= 0 && coordinate.Item2 < Rows &&
        coordinate.Item1 >= 0 && coordinate.Item1 < Cols;

    private Owner GetPlayer(ValueTuple<int, int> coordinate) => board[coordinate.Item2][coordinate.Item1];

    private bool IsEmpty(ValueTuple<int, int> coordinate) => GetPlayer(coordinate) == Owner.None;
    private bool IsTaken(ValueTuple<int, int> coordinate) => !IsEmpty(coordinate);

    private IEnumerable<ValueTuple<int, int>> EmptyCoordinates()
    {
        return Enumerable.Range(0, Cols).SelectMany(col =>
               Enumerable.Range(0, Rows).Select(row => new ValueTuple<int, int>(col, row)))
                .Where(IsEmpty);
    }

    private IEnumerable<ValueTuple<int, int>> NeighborCoordinates(ValueTuple<int, int> coordinate)
    {
        var row = coordinate.Item2;
        var col = coordinate.Item1;

        var coords = new[]
        {
            new ValueTuple<int, int>(col,   row - 1),
            new ValueTuple<int, int>(col-1, row),
            new ValueTuple<int, int>(col+1, row),
            new ValueTuple<int, int>(col,   row+1)
        };

        return coords.Where(IsValidCoordinate);
    }

    private IEnumerable<ValueTuple<int, int>> TakenNeighborCoordinates(ValueTuple<int, int> coordinate) =>
        NeighborCoordinates(coordinate).Where(IsTaken);

    private IEnumerable<ValueTuple<int, int>> EmptyNeighborCoordinates(ValueTuple<int, int> coordinate) =>
        NeighborCoordinates(coordinate).Where(IsEmpty);

    private Owner TerritoryOwner(IEnumerable<ValueTuple<int, int>> coords)
    {
        var neighborColors = coords.SelectMany(TakenNeighborCoordinates).Select(GetPlayer);
        var uniqueNeighborColors = ToSet(neighborColors);

        if (uniqueNeighborColors.Count == 1)
            return uniqueNeighborColors.First();

        return Owner.None;
    }

    private HashSet<ValueTuple<int, int>> TerritoryHelper(HashSet<ValueTuple<int, int>> remainder, HashSet<ValueTuple<int, int>> acc)
    {
        if (!remainder.Any())
            return acc;

        var emptyNeighbors = new HashSet<ValueTuple<int, int>>(remainder.SelectMany(EmptyNeighborCoordinates));
        emptyNeighbors.ExceptWith(acc);

        var newAcc = ToSet(acc);
        newAcc.UnionWith(emptyNeighbors);
        return TerritoryHelper(emptyNeighbors, newAcc);
    }

    private HashSet<ValueTuple<int, int>> TerritoryHelper(ValueTuple<int, int> coordinate) =>
        IsValidCoordinate(coordinate) && IsEmpty(coordinate)
            ? TerritoryHelper(ToSingletonSet(coordinate), ToSingletonSet(coordinate))
            : new HashSet<ValueTuple<int, int>>();

    public ValueTuple<Owner, IEnumerable<ValueTuple<int, int>>> Territory(ValueTuple<int, int> coord)
    {
        if (coord.Item1 < 0 || coord.Item1 >= Rows || coord.Item2 < 0 || coord.Item2 >= Cols)
        {
            throw new ArgumentException();
        }
        
        var coords = TerritoryHelper(coord);
        if (!coords.Any())
            return (Owner.None, Enumerable.Empty<ValueTuple<int, int>>());

        var owner = TerritoryOwner(coords);
        return (owner, coords.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToArray());
    }

    private Dictionary<Owner, ValueTuple<int, int>[]> TerritoriesHelper(HashSet<ValueTuple<int, int>> remainder, Dictionary<Owner, ValueTuple<int, int>[]> acc)
    {
        if (!remainder.Any())
            return acc;

        var coord = remainder.First();
        var coords = TerritoryHelper(coord);
        var owner = TerritoryOwner(coords);

        var newRemainder = ToSet(remainder);
        newRemainder.ExceptWith(coords);

        acc[owner] = acc[owner].Concat(coords).ToArray();
        return TerritoriesHelper(newRemainder, acc);
    }

    public Dictionary<Owner, ValueTuple<int, int>[]> Territories()
    {
        var emptyCoords = EmptyCoordinates();

        var territories = new Dictionary<Owner, ValueTuple<int, int>[]>
        {
            [Owner.Black] = new ValueTuple<int, int>[0],
            [Owner.White] = new ValueTuple<int, int>[0],
            [Owner.None] = new ValueTuple<int, int>[0]
        };
        
        return TerritoriesHelper(ToSet(emptyCoords), territories);
    }

    private static HashSet<T> ToSet<T>(IEnumerable<T> value) => new HashSet<T>(value);
    private static HashSet<T> ToSingletonSet<T>(T value) => new HashSet<T> { value };    
}