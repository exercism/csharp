using System.Collections.Generic;

public class Pangram
{
    public static bool IsPangram(string input)
    {
        var chars = new HashSet<char>();

        foreach (var c in input.ToLowerInvariant())
        {
            if (c >= 'a' && c <= 'z')
            {
                chars.Add(c);
            }
        }

        return chars.Count == 26;
    }
}
