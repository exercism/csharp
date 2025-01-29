using Humanizer;

namespace Generators;

internal static class Naming
{
    internal static string ToMethodName(params object[] path) =>
        path.Cast<string>()
            .Unwords()
            .Words()
            .Select(Transform)
            .Unwords()
            .Underscore()
            .Transform(To.SentenceCase);

    private static string Transform(string str, int index) =>
        index == 0 && int.TryParse(str, out var i)
            ? i.ToWords()
            : str.Dehumanize();
    
    private static IEnumerable<string> Words(this string str) => str.Split(' ');
    private static string Unwords(this IEnumerable<string> strs) => string.Join(' ', strs);
}