using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        return Words(phrase).Aggregate("", (abbr, word) => abbr + char.ToUpperInvariant(word[0]));
    }

    private static IEnumerable<string> Words(string phrase)
    {
        return Regex.Matches(phrase, "[A-Z]+[a-z']*|[a-z']+").Cast<Match>().Select(m => m.Value);
    }
}