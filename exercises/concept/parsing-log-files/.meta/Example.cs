using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsMatch(string text)
    {
        const string searchArg = @"^(\[TRC\] | \[DBG\] | \[INF\] | \[ERR\] | \[WRN\] | \[FTL\])";
        return Regex.IsMatch(text, searchArg, RegexOptions.IgnorePatternWhitespace);
    }

    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, "<[*^=-]*>");
    }

    public int CountQuotedPasswords(string lines)
    {
        bool[] results = new bool[lines.Length];
        var regex = new Regex(@"^.*""[^\\""]*password[^\\""]*"".*$",
            RegexOptions.IgnoreCase | RegexOptions.Multiline);
        var matches = regex.Matches(lines);
        return matches.Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        string pattern = @"end-of-Line\d+";

        return Regex.Replace(line, pattern, string.Empty,
            RegexOptions.IgnoreCase);
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var pattern = @".*\s(?<pw>password\S+).*";

        string[] outlines = new string[lines.Length];
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
        for (int i = 0; i < lines.Length; i++)
        {
            var matches = regex.Matches(lines[i]);
            if (matches.Count > 0)
            {
                var grps = matches[0].Groups;
                outlines[i]
                  = $"{grps["pw"].Value}: {lines[i]}";
            }
            else
            {
                outlines[i] = $"--------: {lines[i]}";
            }
        }

        return outlines;
    }
}
