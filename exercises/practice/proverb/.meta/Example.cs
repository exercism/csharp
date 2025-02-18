using System;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        Func<int, string> line = (lineIndex) =>
        {
            if (lineIndex == subjects.Length) return $"And all for the want of a {subjects[0]}.";
            else return $"For want of a {subjects[lineIndex - 1]} the {subjects[lineIndex]} was lost.";
        };

        return Enumerable.Range(1, subjects.Length).Select(line).ToArray();
    }
}