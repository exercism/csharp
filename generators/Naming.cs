using System.Text.RegularExpressions;
using Humanizer;

namespace Generators;

internal static class Naming
{
    internal static string ToMethodName(string property) =>
        property.Dehumanize();

    internal static string ToTestMethodName(params string[] path) =>
        path.Unwords()
            .Words()
            .Select(Transform)
            .Unwords()
            .Underscore()
            .Transform(To.SentenceCase);

    private static string Transform(string str, int index) =>
        index == 0 && int.TryParse(str, out var i)
            ? i.ToWords()
            : str.Dehumanize();

    private static IEnumerable<string> Words(this string str) => 
        Regex.Split(str, @"\W+")
            .Where(s => !string.IsNullOrWhiteSpace(s));
    
    private static string Unwords(this IEnumerable<string> strs) => string.Join(' ', strs);
}