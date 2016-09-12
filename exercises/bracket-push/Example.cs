using System.Linq;

public static class BracketPush
{
    public static bool Matched(string input)
    {
        var brackets = new string(input.Where(c => "[]{}()".Contains(c)).ToArray());
        var previousLength = brackets.Length;

        while (brackets.Length > 0)
        {
            brackets = brackets.Replace("[]", "").Replace("{}", "").Replace("()", "");

            if (brackets.Length == previousLength)
            {
                return false;
            }
        }

        return true;
    }
}
