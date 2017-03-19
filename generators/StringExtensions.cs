namespace Generators
{
    public static class StringExtensions
    {
        public static string EnsureStartsWith(this string str, string value)
            => str.StartsWith(value) ? str : value + str;
    }
}