using System;
using System.Collections.Generic;
using System.Linq;

public static class Transpose
{
    public static string String(string input)
    {
        var paddedRows = PadRows(input.Split('\n'));

        return string.Join("\n",
                paddedRows
                .SelectMany(s => s.Select((c, i) => Tuple.Create(i, c)))
                .GroupBy(x => x.Item1)
                .Select(x => new string(x.Select(y => y.Item2).ToArray())));
    }

    private static IEnumerable<string> PadRows(string[] rows)
    {
        var maxLength = rows.Max(x => x.Length);
        return rows.Select((row, i) => i < rows.Length - 1 ? row.PadRight(maxLength) : row);
    }
}