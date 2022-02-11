using System;
using System.Linq;

public static class Rectangles
{
    public static int Count(string[] rows)
    {
        var grid = ParseGrid(rows);
        var corners = FindCorners(grid);
        return corners.Sum(corner => RectangleForCorner(corner, corners, grid));
    }

    private static CellType[][] ParseGrid(string[] rows)
        => rows.Select(row => row.Select(ParseCell).ToArray()).ToArray();

    private static CellType ParseCell(char cell)
    {
        switch (cell)
        {
            case '+':
                return CellType.Corner;
            case '-':
                return CellType.HorizontalLine;
            case '|':
                return CellType.VerticalLine;
            case ' ':
                return CellType.Empty;
            default:
                throw new ArgumentException();
        }
    }

    private static int Rows(CellType[][] grid) => grid.Length;

    private static int Cols(CellType[][] grid) => grid[0].Length;

    private static CellType Cell(Tuple<int, int> point, CellType[][] grid) => grid[point.Item2][point.Item1];

    private static Tuple<int, int>[] FindCorners(CellType[][] grid) =>
        Enumerable.Range(0, Rows(grid)).SelectMany(y =>
                    Enumerable.Range(0, Cols(grid)).Select(x => new Tuple<int, int>(x, y)))
            .Where(point => Cell(point, grid) == CellType.Corner)
            .ToArray();

    private static bool ConnectsVertically(Tuple<int, int> point, CellType[][] grid) =>
        (Cell(point, grid) == CellType.VerticalLine) ||
        (Cell(point, grid) == CellType.Corner);

    private static bool ConnectedVertically(Tuple<int, int> top, Tuple<int, int> bottom, CellType[][] grid) =>
        Enumerable.Range(top.Item2 + 1, bottom.Item2 - top.Item2 - 1).All(y => ConnectsVertically(new Tuple<int, int>(top.Item1, y), grid));

    private static bool ConnectsHorizontally(Tuple<int, int> point, CellType[][] grid) =>
        (Cell(point, grid) == CellType.HorizontalLine) ||
        (Cell(point, grid) == CellType.Corner);

    private static bool ConnectedHorizontally(Tuple<int, int> left, Tuple<int, int> right, CellType[][] grid) =>
        Enumerable.Range(left.Item1 + 1, right.Item1 - left.Item1 - 1).All(x => ConnectsHorizontally(new Tuple<int, int>(x, left.Item2), grid));

    private static bool IsTopLineOfRectangle(Tuple<int, int> topLeft, Tuple<int, int> topRight, CellType[][] grid) =>
        (topRight.Item1 > topLeft.Item1) && (topRight.Item2 == topLeft.Item2) && ConnectedHorizontally(topLeft, topRight, grid);

    private static bool IsRightLineOfRectangle(Tuple<int, int> topRight, Tuple<int, int> bottomRight, CellType[][] grid) =>
        (bottomRight.Item1 == topRight.Item1) && (bottomRight.Item2 > topRight.Item2) &&
        ConnectedVertically(topRight, bottomRight, grid);

    private static bool IsBottomLineOfRectangle(Tuple<int, int> bottomLeft, Tuple<int, int> bottomRight, CellType[][] grid) =>
        (bottomRight.Item1 > bottomLeft.Item1) && (bottomRight.Item2 == bottomLeft.Item2) &&
        ConnectedHorizontally(bottomLeft, bottomRight, grid);

    private static bool IsLeftLineOfRectangle(Tuple<int, int> topLeft, Tuple<int, int> bottomLeft, CellType[][] grid) =>
        (bottomLeft.Item1 == topLeft.Item1) && (bottomLeft.Item2 > topLeft.Item2) && ConnectedVertically(topLeft, bottomLeft, grid);

    private static int RectangleForCorner(Tuple<int, int> topLeft, Tuple<int, int>[] corners, CellType[][] grid)
    {
        return (from topRight in corners.Where(corner => IsTopLineOfRectangle(topLeft, corner, grid))
                from bottomLeft in corners.Where(corner => IsLeftLineOfRectangle(topLeft, corner, grid))
                from bottomRight in corners.Where(corner => IsRightLineOfRectangle(topRight, corner, grid) &&
                                                            IsBottomLineOfRectangle(bottomLeft, corner, grid))
                select 1)
            .Count();
    }

    private enum CellType
    {
        Empty,
        Corner,
        HorizontalLine,
        VerticalLine
    }
}