using System.Collections.Generic;
using System.Linq;

public class Atbash
{
    private const string PLAIN = "abcdefghijklmnopqrstuvwxyz";
    private const string CIPHER = "zyxwvutsrqponmlkjihgfedcba";

    public static string Encode(string value)
    {
        var encoded = string.Concat(StripInvalidCharacters(value).ToLower().Select(ApplyCipher));
        return SplitIntoFiveLetterWords(encoded);
    }

    private static string StripInvalidCharacters(string value)
    {
        return string.Concat(value.Where(char.IsLetterOrDigit));
    }

    private static char ApplyCipher(char value)
    {
        var idx = PLAIN.IndexOf(value);
        return idx >= 0 ? CIPHER[idx] : value;
    }

    private static string SplitIntoFiveLetterWords(string value)
    {
        var words = new List<string>();

        for (int i = 0; i < value.Length; i += 5)
            words.Add(i + 5 <= value.Length ? value.Substring(i, 5) : value.Substring(i));

        return string.Join(" ", words);
    }
}