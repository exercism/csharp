using System;

public static class ResistorColorTrio
{
    private static readonly string[] Colors = ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"];
    private static readonly string[] Units = ["", "kilo", "mega", "giga"];
    
    public static string Label(string[] colors)
    {
        var ohms = Ohms(colors);

        for (var i = 0; i < Units.Length; ++i)
            if (ohms <= Math.Pow(1000, i + 1))
                return $"{ohms / Math.Pow(1000, i)} {Units[i]}ohms";

        throw new InvalidOperationException();
    }

    private static ulong Ohms(string[] colors) =>
        (Value(colors[0]) * 10 + Value(colors[1])) * (ulong)Math.Pow(10, Value(colors[2])); 
    
    private static ulong Value(string color) => (ulong)Array.IndexOf(Colors, color);
}
