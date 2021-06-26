namespace Exercism.CSharp.Output.Rendering
{
    internal static class RenderExtensions
    {
        private const int IndentSize = 4;

        public static string Indent(this string str) => $"{new string(' ', IndentSize)}{str}";

        public static string EscapeSpecialCharacters(this string str)
            => str.Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace("\r", "\\r")
                .Replace("\"", "\\\"");

        public static string Quote(this string str) => $"\"{str}\"";
        
        public static string Quote(this char c) => $"'{c}'";
    }
}
