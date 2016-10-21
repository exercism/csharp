using System;
using System.Drawing;
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

    private static CellType Cell(Point point, CellType[][] grid) => grid[point.Y][point.X];

    private static Point[] FindCorners(CellType[][] grid) =>
        Enumerable.Range(0, Rows(grid)).SelectMany(y =>
                    Enumerable.Range(0, Cols(grid)).Select(x => new Point(x, y)))
            .Where(point => Cell(point, grid) == CellType.Corner)
            .ToArray();

    private static bool ConnectsVertically(Point point, CellType[][] grid) =>
        (Cell(point, grid) == CellType.VerticalLine) ||
        (Cell(point, grid) == CellType.Corner);

    private static bool ConnectedVertically(Point top, Point bottom, CellType[][] grid) =>
        Enumerable.Range(top.Y + 1, bottom.Y - top.Y - 1).All(y => ConnectsVertically(new Point(top.X, y), grid));

    private static bool ConnectsHorizontally(Point point, CellType[][] grid) =>
        (Cell(point, grid) == CellType.HorizontalLine) ||
        (Cell(point, grid) == CellType.Corner);

    private static bool ConnectedHorizontally(Point left, Point right, CellType[][] grid) =>
        Enumerable.Range(left.X + 1, right.X - left.X - 1).All(x => ConnectsHorizontally(new Point(x, left.Y), grid));

    private static bool IsTopLineOfRectangle(Point topLeft, Point topRight, CellType[][] grid) =>
        (topRight.X > topLeft.X) && (topRight.Y == topLeft.Y) && ConnectedHorizontally(topLeft, topRight, grid);

    private static bool IsRightLineOfRectangle(Point topRight, Point bottomRight, CellType[][] grid) =>
        (bottomRight.X == topRight.X) && (bottomRight.Y > topRight.Y) &&
        ConnectedVertically(topRight, bottomRight, grid);

    private static bool IsBottomLineOfRectangle(Point bottomLeft, Point bottomRight, CellType[][] grid) =>
        (bottomRight.X > bottomLeft.X) && (bottomRight.Y == bottomLeft.Y) &&
        ConnectedHorizontally(bottomLeft, bottomRight, grid);

    private static bool IsLeftLineOfRectangle(Point topLeft, Point bottomLeft, CellType[][] grid) =>
        (bottomLeft.X == topLeft.X) && (bottomLeft.Y > topLeft.Y) && ConnectedVertically(topLeft, bottomLeft, grid);

    private static int RectangleForCorner(Point topLeft, Point[] corners, CellType[][] grid)
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