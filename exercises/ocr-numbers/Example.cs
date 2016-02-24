using System;
using System.Collections.Generic;
using System.Linq;

public static class OcrNumbers
{
    private const int CharacterWidth = 3;
    private const int CharacterHeight = 4;

    public static string Convert(string input)
    {
        var lines = input.Split('\n');
        
        return Positions(lines).Aggregate("", (str, pos) => str + ConvertCharacter(lines, pos.Item1, pos.Item2));
    }

    private static IEnumerable<Tuple<int, int>> Positions(string[] lines)
    {
        return from x in Enumerable.Range(0, Rows(lines))
               from y in Enumerable.Range(0, Cols(lines))
               select Tuple.Create(x, y);
    }

    private static int Cols(string[] lines) => lines[0].Length / CharacterWidth;

    private static int Rows(string[] lines) => lines.Length / CharacterHeight;
    
    private static char ConvertCharacter(string[] input, int row, int col) => MatchCharacter(Character(input, row, col));

    private static string Character(string[] input, int row, int col)
    {
        return Enumerable.Range(row, CharacterHeight)
                         .Aggregate("", (str, offset) => str + input[row * CharacterHeight + offset].Substring(col * CharacterWidth, CharacterWidth));
    }

    private static char MatchCharacter(string character)
    {
        return CharactersMap.ContainsKey(character) ? CharactersMap[character] : '?';
    }

    private static readonly IReadOnlyDictionary<string, char> CharactersMap = new Dictionary<string, char>
    {
        {
            " _ " + 
            "| |" + 
            "|_|" + 
            "   ",
            '0'
        },
        {
            "   " +
            "  |" +
            "  |" +
            "   ",
            '1'
        },
        {
            " _ " +
            " _|" +
            "|_ " +
            "   ",
            '2'
        },
        {
            " _ " +
            " _|" +
            " _|" +
            "   ",
            '3'
        },
        {
            "   " +
            "|_|" +
            "  |" +
            "   ",
            '4'
        },
        {
            " _ " +
            "|_ " +
            " _|" +
            "   ",
            '5'
        },
        {
            " _ " +
            "|_ " +
            "|_|" +
            "   ",
            '6'
        },
        {
            " _ " +
            "  |" +
            "  |" +
            "   ",
            '7'
        },
        {
            " _ " +
            "|_|" +
            "|_|" +
            "   ",
            '8'
        },
        {
            " _ " +
            "|_|" +
            " _|" +
            "   ",
            '9'
        }
    };
}