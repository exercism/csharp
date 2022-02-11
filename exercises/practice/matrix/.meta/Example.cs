using System.Linq;

public class Matrix
{
    private readonly int[][] _rows;
    private readonly int[][] _cols;

    public Matrix(string input)
    {
        _rows = ParseRows(input);
        _cols = ParseCols(_rows);
    }

    public int Rows => _rows.Length;
    public int Cols => _cols.Length;

    public int[] Row(int row) => _rows[row - 1];
    public int[] Column(int col) => _cols[col - 1];

    private static int[][] ParseRows(string input)
    {
        return input.Split('\n')
            .Select(ParseRow)
            .ToArray();
    }

    private static int[] ParseRow(string row)
    {
        return row.Split(' ')
            .Select(int.Parse)
            .ToArray();
    }

    private static int[][] ParseCols(int[][] rows)
    {
        return Enumerable.Range(0, rows[0].Length)
            .Select(y => ParseCol(rows, y))
            .ToArray();
    }

    private static int[] ParseCol(int[][] rows, int y)
    {
        return Enumerable.Range(0, rows.Length)
            .Select(x => rows[x][y])
            .ToArray();
    }
}