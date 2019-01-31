using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var rowCount = matrix.GetLength(0);
        var columnCount = matrix.GetLength(1);
        var maxRows = Rows(matrix, rowCount, columnCount).Select(r => r.Max()).ToArray();
        var minCols = Columns(matrix, columnCount, rowCount).Select(r => r.Min()).ToArray();
        return Coordinates(rowCount, columnCount)
            .Where(x => IsSaddlePoint(x, maxRows, minCols, matrix))
            .Select(pair => (pair.Item1 + 1, pair.Item2 + 1))
            .ToArray();
    }

    private static IEnumerable<(int, int)> Coordinates(int rowCount, int columnCount)
    {
        return Enumerable.Range(0, rowCount)
            .SelectMany(x => Enumerable.Range(0, columnCount).Select(y => (x, y)));
    }

    private static IEnumerable<IEnumerable<int>> Columns(int[,] matrix, int columnCount, int rowCount)
    {
        return Enumerable.Range(0, columnCount)
            .Select(y => Enumerable.Range(0, rowCount).Select(x => matrix[x, y]));
    }

    private static IEnumerable<IEnumerable<int>> Rows(int[,] matrix, int rowCount, int columnCount)
    {
        return Enumerable.Range(0, rowCount)
            .Select(x => Enumerable.Range(0, columnCount).Select(y => matrix[x, y]));
    }

    private static bool IsSaddlePoint((int, int) coordinate, int [] maxRows, int [] minCols, int[,] matrix)
    {
        return maxRows[coordinate.Item1] == matrix[coordinate.Item1, coordinate.Item2] &&
               minCols[coordinate.Item2] == matrix[coordinate.Item1, coordinate.Item2];
    }

}
