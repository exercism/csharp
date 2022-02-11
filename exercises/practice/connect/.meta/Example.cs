using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public enum ConnectWinner
{
    White,
    Black,
    None
}

public class Connect
{
    private enum Cell
    {
        Empty,
        White,
        Black
    }

    private readonly Cell[][] board;

    public Connect(string[] input)
    {
        board = ParseBoard(input);
    }

    private static Cell CharToCell(char c)
    {
        switch (c)
        {
            case 'O': return Cell.White;
            case 'X': return Cell.Black;
            default: return Cell.Empty;
        }
    }

    private static Cell[][] ParseBoard(string[] input)
    {
        var rows = input.Length;
        var cols = input[0].Length;
        var filtered = new List<string>();
        foreach (var str in input)
        {
            filtered.Add(Regex.Replace(str, @"\s+", ""));
        }
        return filtered.Select(row => row.Select(CharToCell).ToArray()).ToArray();
    }

    private int Cols => board[0].Length;
    private int Rows => board.Length;

    private bool IsValidCoordinate(Tuple<int, int> coordinate) =>
        coordinate.Item2 >= 0 && coordinate.Item2 < Rows &&
        coordinate.Item1 >= 0 && coordinate.Item1 < Cols;

    private bool CellAtCoordinateEquals(Cell cell, Tuple<int, int> coordinate) => board[coordinate.Item2][coordinate.Item1] == cell;

    private HashSet<Tuple<int, int>> Adjacent(Cell cell, Tuple<int, int> coordinate)
    {
        var row = coordinate.Item2;
        var col = coordinate.Item1;

        var coords = new[]
        {
            new Tuple<int, int>(col + 1, row - 1),
            new Tuple<int, int>(col,     row - 1),
            new Tuple<int, int>(col - 1, row    ),
            new Tuple<int, int>(col + 1, row    ),
            new Tuple<int, int>(col - 1, row + 1),
            new Tuple<int, int>(col,     row + 1)
        };

        return new HashSet<Tuple<int, int>>(coords.Where(coord => IsValidCoordinate(coord) && CellAtCoordinateEquals(cell, coord)));
    }
    
    private bool ValidPath(Cell cell, Func<Cell[][], Tuple<int, int>, bool> stop, HashSet<Tuple<int, int>> processed, Tuple<int, int> coordinate)
    {
        if (stop(board, coordinate))
            return true;

        var next = Adjacent(cell, coordinate);
        next.ExceptWith(processed);
        
        if (!next.Any())
            return false;

        return next.Any(nextCoord => {
            var updatedProcessed = new HashSet<Tuple<int, int>>(processed);
            updatedProcessed.Add(nextCoord);

            return ValidPath(cell, stop, updatedProcessed, nextCoord);
        });
    }   

    private bool IsWhiteStop(Cell[][] board, Tuple<int, int> coordinate) => coordinate.Item2 == Rows - 1;
    private bool IsBlackStop(Cell[][] board, Tuple<int, int> coordinate) => coordinate.Item1 == Cols - 1;

    private HashSet<Tuple<int, int>> WhiteStart() =>
        new HashSet<Tuple<int, int>>(Enumerable.Range(0, Cols).Select(col => new Tuple<int, int>(col, 0)).Where(coord => CellAtCoordinateEquals(Cell.White, coord)));
        
    private HashSet<Tuple<int, int>> BlackStart() =>
        new HashSet<Tuple<int, int>>(Enumerable.Range(0, Rows).Select(row => new Tuple<int, int>(0, row)).Where(coord => CellAtCoordinateEquals(Cell.Black, coord)));

    private bool ColorWins(Cell cell, Func<Cell[][], Tuple<int, int>, bool> stop, Func<HashSet<Tuple<int, int>>> start)
    {
        return start().Any(coordinate => ValidPath(cell, stop, new HashSet<Tuple<int, int>>(), coordinate));
    }

    private bool WhiteWins() => ColorWins(Cell.White, IsWhiteStop, WhiteStart);
    private bool BlackWins() => ColorWins(Cell.Black, IsBlackStop, BlackStart);        
    
    public ConnectWinner Result()
    {
        if (WhiteWins())
            return ConnectWinner.White;

        if (BlackWins())
            return ConnectWinner.Black;

        return ConnectWinner.None;
    }
}