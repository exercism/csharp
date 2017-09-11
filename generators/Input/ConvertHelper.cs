namespace Generators.Input
{
    public static class ConvertHelper
    {
        public static string ToMultiLineString(this object obj) => string.Join("\n", obj as object[]);
    }
}