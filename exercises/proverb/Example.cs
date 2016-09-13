using System.Linq;

public static class Proverb
{
    private static readonly string[] Subjects = { "nail", "shoe", "horse", "rider", "message", "battle", "kingdom" };

    public static string Line(int line)
    {
        if (line == 7)
        { 
            return "And all for the want of a horseshoe nail.";
        }

        return $"For want of a {Subjects[line - 1]} the {Subjects[line]} was lost.";
    }

    public static string AllLines() => string.Join("\n", Enumerable.Range(1, 7).Select(Line));
}