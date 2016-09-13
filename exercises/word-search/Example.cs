using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class WordSearch
{
    private readonly string[] rows;
    private readonly int width;
    private readonly int height;

    private static readonly Point[] Directions =
    {
        new Point( 1,  0),
        new Point( 0,  1),
        new Point(-1,  0),
        new Point( 0, -1),
        new Point( 1,  1),
        new Point( 1, -1),
        new Point(-1,  1),
        new Point(-1, -1)
    };

    public WordSearch(string puzzle)
    {
        rows = puzzle.Split('\n');
        width = rows[0].Length;
        height = rows.Length;
    }

    public Tuple<Point, Point> Find(string word)
    {
        return
            Positions()
                .SelectMany(position => Directions.SelectMany(direction => Find(word, position, direction)))
                .FirstOrDefault();
    }

    private IEnumerable<Tuple<Point, Point>> Find(string word, Point position, Point direction)
    {
        var current = position;

        foreach (var letter in word)
        {
            if (FindChar(current) != letter)
            {
                yield break;
            }

            current.X += direction.X;
            current.Y += direction.Y;
        }

        yield return Tuple.Create(position, new Point(current.X - direction.X, current.Y - direction.Y));
    }

    private char? FindChar(Point coordinate)
    {
        if (coordinate.X > 0 && coordinate.X <= width && coordinate.Y > 0 && coordinate.Y <= height)
        {
            return rows[coordinate.Y - 1][coordinate.X - 1];
        }

        return null;
    }

    private IEnumerable<Point> Positions()
    {
        return Enumerable.Range(1, width).SelectMany(x =>
               Enumerable.Range(1, height).Select(y =>new Point(x, y)));
    }
}