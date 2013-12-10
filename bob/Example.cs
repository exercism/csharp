public class Bob
{
    public string Hey(string statement)
    {

        if (IsSilence(statement))
        {
            return "Fine. Be that way!";
        }
        if (IsYelling(statement))
        {
            return "Woah, chill out!";
        }
        if (IsQuestion(statement))
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";
        }

    }

    private bool IsSilence (string statement)
    {
        return statement.Trim() == "";
    }

    private bool IsYelling (string statement)
    {
        return statement.ToUpper() == statement && System.Text.RegularExpressions.Regex.IsMatch(statement, "[a-zA-Z]+");
    }

    private bool IsQuestion (string statement)
    {
        return statement.EndsWith("?");
    }

}