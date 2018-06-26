namespace Exercism.CSharp.Helpers
{
    public static class ConvertHelper
    {
        public static T[] ToArray<T>(this object obj)
        {
            if (obj is T[] arr && arr.Length != 0) 
                return arr;
            
            return new T[0];
        }
    }
}