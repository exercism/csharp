using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] rows;
    private readonly int width;
    private readonly int height;

    private static readonly Tuple<int, int>[] Directions =
    {
        new Tuple<int, int>( 1,  0),
        new Tuple<int, int>( 0,  1),
        new Tuple<int, int>(-1,  0),
        new Tuple<int, int>( 0, -1),
        new Tuple<int, int>( 1,  1),
        new Tuple<int, int>( 1, -1),
        new Tuple<int, int>(-1,  1),
        new Tuple<int, int>(-1, -1)
    };

    public WordSearch(string puzzle)
    {
        rows = puzzle.Split('\n');
        width = rows[0].Length;
        height = rows.Length;
    }

    public Tuple<Tuple<int, int>, Tuple<int, int>> Find(string word)
    {
        return
            Positions()
                .SelectMany(position => Directions.SelectMany(direction => Find(word, position, direction)))
                .FirstOrDefault();
    }

    private IEnumerable<Tuple<Tuple<int, int>, Tuple<int, int>>> Find(string word, Tuple<int, int> position, Tuple<int, int> direction)
    {
        var current = position;

        foreach (var letter in word)
        {
            if (FindChar(current) != letter)
            {
                yield break;
            }

            current = new Tuple<int, int>(current.Item1 + direction.Item1, current.Item2 + direction.Item2);
        }

        yield return Tuple.Create(position, new Tuple<int, int>(current.Item1 - direction.Item1, current.Item2 - direction.Item2));
    }

    private char? FindChar(Tuple<int, int> coordinate)
    {
        if (coordinate.Item1 > 0 && coordinate.Item1 <= width && coordinate.Item2 > 0 && coordinate.Item2 <= height)
        {
            return rows[coordinate.Item2 - 1][coordinate.Item1 - 1];
        }

        return null;
    }

    private IEnumerable<Tuple<int, int>> Positions()
    {
        return Enumerable.Range(1, width).SelectMany(x =>
               Enumerable.Range(1, height).Select(y => new Tuple<int, int>(x, y)));
    }
}