namespace Generators.Input
{
    public static class ConvertHelper
    {
        public static string ToMultiLineString(this object obj) => string.Join("\n", obj as object[]);

        public static string ToMultiLineString(this object obj, string empty)
        {
            if (obj is object[] arr && arr.Length != 0) 
                return string.Join("\n", arr);
            
            return empty;

        }

        public static T[] ToArray<T>(this object obj)
        {
            if (obj is T[] arr && arr.Length != 0) 
                return arr;
            
            return new T[0];

        }
    }
}