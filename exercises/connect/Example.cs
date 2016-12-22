using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class Connect
{
    public enum Winner
    {
        White,
        Black,
        None
    }

    public enum Cell
    {
        Empty,
        White,
        Black
    }

    private readonly Cell[][] board;

    public Connect(string input)
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

    private static Cell[][] ParseBoard(string input)
    {
        var split = input.Split('\n');
        var rows = split.Length;
        var cols = split[0].Length;

        return split.Select(row => row.Select(CharToCell).ToArray()).ToArray();
    }

    private int Cols => board[0].Length;
    private int Rows => board.Length;

    private bool IsValidCoordinate(Point coordinate) =>
        coordinate.Y >= 0 && coordinate.Y < Rows &&
        coordinate.X >= 0 && coordinate.X < Cols;

    private bool CellAtCoordinateEquals(Cell cell, Point coordinate) => board[coordinate.Y][coordinate.X] == cell;

    private HashSet<Point> Adjacent(Cell cell, Point coordinate)
    {
        var row = coordinate.Y;
        var col = coordinate.X;

        var coords = new[]
        {
            new Point(col + 1, row - 1),
            new Point(col,     row - 1),
            new Point(col - 1, row    ),
            new Point(col + 1, row    ),
            new Point(col - 1, row + 1),
            new Point(col,     row + 1)
        };

        return new HashSet<Point>(coords.Where(coord => IsValidCoordinate(coord) && CellAtCoordinateEquals(cell, coord)));
    }
    
    private bool ValidPath(Cell cell, Func<Cell[][], Point, bool> stop, HashSet<Point> processed, Point coordinate)
    {
        if (stop(board, coordinate))
            return true;

        var next = Adjacent(cell, coordinate);
        next.ExceptWith(processed);
        
        if (!next.Any())
            return false;

        return next.Any(nextCoord => {
            var updatedProcessed = new HashSet<Point>(processed);
            updatedProcessed.Add(nextCoord);

            return ValidPath(cell, stop, updatedProcessed, nextCoord);
        });
    }   

    private bool IsWhiteStop(Cell[][] board, Point coordinate) => coordinate.Y == Rows - 1;
    private bool IsBlackStop(Cell[][] board, Point coordinate) => coordinate.X == Cols - 1;

    private HashSet<Point> WhiteStart() =>
        new HashSet<Point>(Enumerable.Range(0, Cols).Select(col => new Point(col, 0)).Where(coord => CellAtCoordinateEquals(Cell.White, coord)));
        
    private HashSet<Point> BlackStart() =>
        new HashSet<Point>(Enumerable.Range(0, Rows).Select(row => new Point(0, row)).Where(coord => CellAtCoordinateEquals(Cell.Black, coord)));

    private bool ColorWins(Cell cell, Func<Cell[][], Point, bool> stop, Func<HashSet<Point>> start)
    {
        return start().Any(coordinate => ValidPath(cell, stop, new HashSet<Point>(), coordinate));
    }

    private bool WhiteWins() => ColorWins(Cell.White, IsWhiteStop, WhiteStart);
    private bool BlackWins() => ColorWins(Cell.Black, IsBlackStop, BlackStart);        
    
    public Winner Result()
    {
        if (WhiteWins())
            return Winner.White;

        if (BlackWins())
            return Winner.Black;

        return Winner.None;
    }
}