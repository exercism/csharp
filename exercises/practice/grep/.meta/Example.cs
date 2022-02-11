using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Grep
{
    private class Line
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string File { get; set; }
    }

    [Flags]
    private enum Flags
    {
        None = 0,
        PrintLineNumbers = 1,
        PrintFileNames = 2,
        CaseInsensitive = 4,
        Invert = 8,
        MatchEntireLines = 16
    }

    public static string Match(string pattern, string flags, string[] files)
    {
        var parsedFlags = ParseFlags(flags);

        if (parsedFlags.HasFlag(Flags.PrintFileNames))
        {
            return FormatMatchingFiles(pattern, parsedFlags, files);
        }

        return FormatMatchingLines(pattern, parsedFlags, files);
    }

    private static Flags ParseFlags(string flags) => flags.Split(' ').Aggregate(Flags.None, (acc, flag) => acc | ParseFlag(flag));

    private static Flags ParseFlag(string flag)
    {
        switch (flag)
        {
            case "-n": return Flags.PrintLineNumbers;
            case "-l": return Flags.PrintFileNames;
            case "-i": return Flags.CaseInsensitive;
            case "-v": return Flags.Invert;
            case "-x": return Flags.MatchEntireLines;
            default: return Flags.None;
        }
    }

    private static Func<Line, bool> IsMatch(string pattern, Flags flags)
    {
        var matchPattern = flags.HasFlag(Flags.MatchEntireLines) ? $"^{pattern}$" : pattern;
        var options = flags.HasFlag(Flags.CaseInsensitive) ? RegexOptions.IgnoreCase : RegexOptions.None;
        var regex = new Regex(matchPattern, options);

        return line => regex.IsMatch(line.Text) != flags.HasFlag(Flags.Invert);
    }

    private static IEnumerable<Line> FindMatchingLines(string pattern, Flags flags, string file)
    {
        var isMatch = IsMatch(pattern, flags);

        return File.ReadAllLines(file)
            .Select((line, index) => CreateLine(file, index, line))
            .Where(isMatch);
    }

    private static Line CreateLine(string file, int index, string text) => new Line { File = file, Number = index + 1, Text = text };

    private static string FormatMatchingFile(string file) => $"{file}";

    private static string FormatMatchingFiles(string pattern, Flags flags, string[] files)
    {
        var matchingFiles = files
            .Where(file => FindMatchingLines(pattern, flags, file).Any())
            .Select(FormatMatchingFile);

        return string.Join("\n", matchingFiles);
    }
    
    private static string FormatMatchingLine(Flags flags, string[] files, Line line)
    {
        var printLineNumbers = flags.HasFlag(Flags.PrintLineNumbers);
        var printFileName = files.Length > 1;

        if (printLineNumbers && printFileName)
        {
            return $"{line.File}:{line.Number}:{line.Text}";
        }
        if (printLineNumbers && !printFileName)
        {
            return $"{line.Number}:{line.Text}";
        }
        if (!printLineNumbers && printFileName)
        {
            return $"{line.File}:{line.Text}";
        }

        return $"{line.Text}";
    }

    private static string FormatMatchingLines(string pattern, Flags flags, string[] files)
    {
        var matchingFiles = files
            .SelectMany(file => FindMatchingLines(pattern, flags, file))
            .Select(line => FormatMatchingLine(flags, files, line));

        return string.Join("\n", matchingFiles);
    }
}