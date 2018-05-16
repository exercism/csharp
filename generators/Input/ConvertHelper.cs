namespace Generators.Input
{
    public static class ConvertHelper
    {
        public static string ToMultiLineString(this object obj) => string.Join("\n", obj as object[]);

        public static string ToMultiLineString(this object obj, string empty)
        {
            var arr = obj as object[];

            if (arr == null || arr.Length == 0)
                return empty;

            return string.Join("\n", obj as object[]);
        }

        public static T[] ToArray<T>(this object obj)
        {
            var arr = obj as T[];

            if (arr == null || arr.Length == 0)
                return new T[0];

            return arr;
        }
    }
}