using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var UNDERSCORE = '_';
        var DASH = '-';
        var ALPHA = 'α';
        var OMEGA = 'ω';
        var sb = new StringBuilder();
        for (int i = 0; i < identifier.Length; i++)
        {
            char ch = identifier[i];
            if (Char.IsWhiteSpace(ch))
            {
                sb.Append(UNDERSCORE);
            }
            else if (Char.IsControl(ch))
            {
                sb.Append("CTRL");
            }
            else if (ch == DASH)
            {
                if (i + 1 < identifier.Length)
                {
                    sb.Append(Char.ToUpper(identifier[i + 1]));
                    i++;
                }
            }
            else if (Char.IsLetter(ch) && (ch < ALPHA || ch > OMEGA) || ch == UNDERSCORE)
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }
}
