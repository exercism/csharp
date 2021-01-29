using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColorDuo
{
    public static int Value(string[] colors) => concat(colors.Take(2)
                                                             .Select(c => Array.IndexOf(AllColors, c))
                                                      );

    private static int concat(IEnumerable<int> numbers)
    {
        return int.Parse(numbers.Aggregate("", (acc, num) => acc + num));
    }

     private static readonly string[] AllColors = new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
}

// An Alternative implementation that doesn't utilize LINQ
// public static class ResistorColorDuo
// {
//     public static int Value(string[] colors) => Value(colors[0]) * 10 + Value(colors[1]);
//     public static int Value(string color) => Array.IndexOf(AllColors, color);
//     private static readonly string[] AllColors = new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
// }