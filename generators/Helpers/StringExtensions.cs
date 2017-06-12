namespace Generators.Helpers
{
    public static class StringExtensions
    {
        public static string EnsureStartsWith(this string str, string value)
            => str.StartsWith(value) ? str : value + str;

        public static bool IsQuoted(this string str)
            => str.StartsWith("\"") && str.EndsWith("\"");
    }
}