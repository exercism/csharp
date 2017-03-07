using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordProblem
{
    private static readonly Regex VariableAndOperatorGroupsRegex =
        new Regex(string.Format(@"{0} {1} {0}\s*{1}*\s*{0}*", @"(-?\d+)", "(plus|minus|multiplied by|divided by)"));
    private static readonly Dictionary<string, Func<int, int, int>> Operations = new Dictionary<string, Func<int, int, int>>
        {
            { "plus", (x, y) => x + y },
            { "minus", (x, y) => x - y },
            { "multiplied by", (x, y) => x * y },
            { "divided by", (x, y) => x / y },
        };

    public static int Solve(string problem)
    {
        var parsedProblem = ParseProblem(problem);
        var firstPass = Operations[parsedProblem.Operation1](parsedProblem.X, parsedProblem.Y);
        if (parsedProblem.Operation2.Length == 0)
            return firstPass;
        return Operations[parsedProblem.Operation2](firstPass, parsedProblem.Z);
    }

    private static ParsedProblem ParseProblem(string problem)
    {
        var match = VariableAndOperatorGroupsRegex.Match(problem);

        if (match.Groups.Count < 6)
            throw new ArgumentException("Invalid problem");

        return new ParsedProblem
            {
                X = int.Parse(match.Groups[1].Value),
                Operation1 = match.Groups[2].Value,
                Y = int.Parse(match.Groups[3].Value),
                Operation2 = match.Groups[4].Value,
                Z = match.Groups[5].Success ? int.Parse(match.Groups[5].Value) : 0
            };
    }

    private class ParsedProblem
    {
        public int X;
        public string Operation1;
        public int Y;
        public string Operation2;
        public int Z;
    }
}