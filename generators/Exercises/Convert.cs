namespace Generators.Exercises
{
    public static class Convert
    {
        public static string ToMultiLineString(this object obj) => string.Join("\n", obj as object[]);
    }
}