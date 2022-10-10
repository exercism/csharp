using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    private static readonly string[] ChromaticScale = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    private static readonly string[] FlatChromaticScale = { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
    private static readonly string[] FlatKeys = { "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb" };

    private static readonly Dictionary<char, int> Intervals = new() { ['m'] = 1, ['M'] = 2, ['A'] = 3 };
    
    private static string[] Scale(string tonic) => FlatKeys.Contains(tonic) ? FlatChromaticScale : ChromaticScale;
    private static string[] SkipInterval(char interval, string[] scale) => scale.Skip(Intervals[interval]).ToArray();
    private static string[] Shift(int index, string[] scale) => scale.Skip(index).Concat(scale.Take(index)).ToArray();

    public static string[] Chromatic(string tonic) => Interval(tonic, "mmmmmmmmmmmm").SkipLast(1).ToArray();

    public static string[] Interval(string tonic, string pattern)
    {
        var scale = Scale(tonic);
        var index = Array.FindIndex(scale, pitch => string.Equals(pitch, tonic, StringComparison.OrdinalIgnoreCase));
        var shiftedScale = Shift(index, scale);
        var shiftedScaleTonic = shiftedScale[0];

        var pitches = new List<string>();

        foreach (var interval in pattern)
        {
            pitches.Add(shiftedScale[0]);
            shiftedScale = SkipInterval(interval, shiftedScale);
        }
        
        pitches.Add(shiftedScaleTonic);

        return pitches.ToArray();
    }
}