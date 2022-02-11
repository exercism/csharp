using System;

public static class ResistorColor
{
    private static readonly string[] AllColors = new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color) => Array.IndexOf(AllColors, color);

    public static string[] Colors() => AllColors;
}