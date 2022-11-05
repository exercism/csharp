using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

[MemoryDiagnoser]
public class BenchMe
{
    private readonly string message = "message";

    [Benchmark]
    public string ResponseIfChain()
    {
        if (IsSilence(message))
            return "Fine. Be that way!";

        if (IsYell(message) && IsQuestion(message))
            return "Calm down, I know what I'm doing!";

        if (IsYell(message))
            return "Whoa, chill out!";

        if (IsQuestion(message))
            return "Sure.";

        return "Whatever.";
    }

    private bool IsSilence(string message) =>
        string.IsNullOrWhiteSpace(message);

    private bool IsYell(string message) =>
        message.Any(char.IsLetter) && message.ToUpperInvariant() == message;

    private bool IsQuestion(string message) =>
        message.TrimEnd().EndsWith("?");

    private bool isShoutForSwitch(string input) => input.Any(c => char.IsLetter(c)) && input.ToUpper() == input;

    [Benchmark]
    public string ResponseWithSwitch()
    {
        var input = message.TrimEnd();
        if (input == "") return "Fine. Be that way!";

        switch ((input.EndsWith('?'), isShoutForSwitch(input)))
        {
            case (true, true): return "Calm down, I know what I'm doing!";
            case (_, true): return "Whoa, chill out!";
            case (true, _): return "Sure.";
            default: return "Whatever.";
        }
    }


    private readonly string[] answers = { "Whatever.", "Sure.", "Whoa, chill out!", "Calm down, I know what I'm doing!" };

    [Benchmark]
    public string ResponseWithArray()
    {
        var input = message.TrimEnd();
        if (input == "") return "Fine. Be that way!";

        var isShout = (input.Any(c => char.IsLetter(c)) && input.ToUpper() == input) ? 2 : 0;

        var isQuestion = (input.EndsWith('?')) ? 1 : 0;

        return answers[isShout + isQuestion];
    }

    [Benchmark]
    public string ResponseRegex()
    {
        if (IsSilenceRegex(message))
            return "Fine. Be that way!";

        if (IsYellRegex(message) && IsQuestionRegex(message))
            return "Calm down, I know what I'm doing!";

        if (IsYellRegex(message))
            return "Whoa, chill out!";

        if (IsQuestionRegex(message))
            return "Sure.";

        return "Whatever.";
    }

    private static bool IsSilenceRegex(string message) =>
        Regex.IsMatch(message, @"^\s*$");

    private static bool IsYellRegex(string message) =>
        Regex.IsMatch(message, @"^[^\p{Ll}]*\p{Lu}+[^\p{Ll}]*$");

    private static bool IsQuestionRegex(string message) =>
        Regex.IsMatch(message, @"\?\s*$");
}

static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<BenchMe>();
    }
}
