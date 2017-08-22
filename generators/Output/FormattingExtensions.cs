namespace Generators.Output
{
    public static class FormattingExtensions
    {
        public static string Indent(this string str, int level = 1) => $"{new string(' ', 4 * level)}{str}";

        public static string EscapeSpecialCharacters(this string s)
            => s.Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace("\r", "\\r")
                .Replace("\"", "\\\"");
                

        public static string Quote(this string s) => $"\"{s}\"";
    }
}
