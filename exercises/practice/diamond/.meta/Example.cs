using System;
using System.Linq;

public static class Diamond
{
    public static string Make(char target)
    {
        var letters = GetLetters(target);
        var diamondLetters = letters.Concat(letters.Reverse().Skip(1)).ToArray();

        return string.Join("\n", diamondLetters.Select(diamondLetter => MakeLine(letters.Length, diamondLetter)));
    }

    private static Tuple<char, int>[] GetLetters(char target) =>
        Enumerable
            .Range('A', target - 'A' + 1)
            .Select((c, i) => Tuple.Create((char)c, i))
            .ToArray();

    private static string MakeLine(int letterCount, Tuple<char, int> rowLetter)
    {
        var letter = rowLetter.Item1;
        var row = rowLetter.Item2;
        var outerSpaces = "".PadRight(letterCount - row - 1);
        var innerSpaces = "".PadRight(row == 0 ? 0 : row * 2 - 1);

        return letter == 'A' ? $"{outerSpaces}{letter}{outerSpaces}" : $"{outerSpaces}{letter}{innerSpaces}{letter}{outerSpaces}";
    }
}