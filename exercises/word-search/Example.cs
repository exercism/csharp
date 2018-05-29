using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] rows;
    private readonly int width;
    private readonly int height;
    private (int, int)[] positions;

    private static readonly ValueTuple<int, int>[] Directions =
    {
        ( 1,  0),
        ( 0,  1),
        (-1,  0),
        ( 0, -1),
        ( 1,  1),
        ( 1, -1),
        (-1,  1),
        (-1, -1)
    };

    public WordSearch(string puzzle)
    {
        rows = puzzle.Split('\n');
        width = rows[0].Length;
        height = rows.Length;
        positions = Positions();
    }

    public Dictionary<string, ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>?> Search(IEnumerable<string> words)
    {
        return words.ToDictionary(word => word, Search);
    }

    private ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>? Search(string word)
    {
        return
            Positions()
                .SelectMany(position => Directions.SelectMany(direction => Find(word, position, direction)))
                .FirstOrDefault();
    }

    private IEnumerable<ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>> Find(string word, ValueTuple<int, int> position, ValueTuple<int, int> direction)
    {
        var current = position;

        foreach (var letter in word)
        {
            if (FindChar(current) != letter)
            {
                yield break;
            }

            current = (current.Item1 + direction.Item1, current.Item2 + direction.Item2);
        }

        yield return ValueTuple.Create(position, (current.Item1 - direction.Item1, current.Item2 - direction.Item2));
    }

    private char? FindChar(ValueTuple<int, int> coordinate)
    {
        if (coordinate.Item1 > 0 && coordinate.Item1 <= width && coordinate.Item2 > 0 && coordinate.Item2 <= height)
        {
            return rows[coordinate.Item2 - 1][coordinate.Item1 - 1];
        }

        return null;
    }

    private ValueTuple<int, int>[] Positions()
    {
        return Enumerable.Range(1, width).SelectMany(x =>
               Enumerable.Range(1, height).Select(y => (x, y)))
                .ToArray();
    }
}