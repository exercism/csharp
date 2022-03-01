using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input) => string.Join("", GroupConsecutive(input).Select(EncodeConsecutive));

    private static string EncodeConsecutive(Tuple<char, int> group) => group.Item2 > 1 ? $"{group.Item2}{group.Item1}" : group.Item1.ToString();

    private static IEnumerable<Tuple<char, int>> GroupConsecutive(string input)
    {
        if (input.Length == 0)
        {
            yield break;
        }

        var current = input[0];
        var count = 0;

        foreach (var character in input)
        {
            if (character == current)
            {
                count++;
            }
            else
            {
                yield return Tuple.Create(current, count);
                current = character;
                count = 1;
            }
        }

        yield return Tuple.Create(current, count);
    }

    public static string Decode(string input) => string.Join("", Regex.Matches(input, @"(\d+[^\d]|[^\d])").Cast<Match>().Select(Decode));

    private static string Decode(Match match)
    {
        if (EncodedSingleCharacter(match))
        {
            return match.Value;
        }

        return DecodeConsecutiveCharacters(match);
    }

    private static bool EncodedSingleCharacter(Match match) => match.Value.Length == 1;

    private static string DecodeConsecutiveCharacters(Match match)
    {
        var character = match.Value[match.Value.Length - 1];
        var count = int.Parse(match.Value.Substring(0, match.Value.Length - 1));
        return new string(character, count);
    }
}
