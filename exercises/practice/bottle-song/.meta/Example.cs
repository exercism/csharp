using System;
using System.Collections.Generic;
using System.Linq;

public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
        => Enumerable
            .Range(startBottles - takeDown + 1, takeDown)
            .Reverse()
            .Select(Verse)
            .SelectMany((v, i) =>
            {
                if (i == 0)
                {
                    return v;
                } 
                List<string> delimiter = [string.Empty];
                return delimiter.Concat(v);
            })
            .ToList();

    private static List<string> Verse(int number)
    {
        string bottles = number == 1 ? "bottle" : "bottles";
        string nextBottles = (number - 1) == 1 ? "bottle" : "bottles";
        string currCount = DecimalToOrdinal(number);
        string nextCount = DecimalToOrdinal(number - 1);

        return [
            $"{currCount} green {bottles} hanging on the wall,",
            $"{currCount} green {bottles} hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            $"There'll be {nextCount.ToLowerInvariant()} green {nextBottles} hanging on the wall."
        ];
    }

    private static string DecimalToOrdinal(int number)
        => number switch
        {
            0 => "No",
            1 => "One",
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            6 => "Six",
            7 => "Seven",
            8 => "Eight",
            9 => "Nine",
            10 => "Ten",
            _ => throw new NotImplementedException()
        };
}