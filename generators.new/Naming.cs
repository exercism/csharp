using Humanizer;

namespace Generators;

internal static class Naming
{
    internal static string ToMethodName(params object[] path)
    {
        var stringPath = path.Select(obj => obj.ToString()!).ToArray();
            
        // Fix method names that start with a number
        if (char.IsNumber(stringPath[0][0]))
            stringPath[0] = NumberToWord(stringPath[0]);

        return string.Join("_", stringPath.Select(str => str.Dehumanize())).Underscore().Transform(To.SentenceCase);
    }

    private static string NumberToWord(string str)
    {
        var parts = str.Split(' ');
        var word = Convert.ToInt32(parts[0]).ToWords();
        return string.Join(" ", [word, ..parts[1..]]);
    }
}