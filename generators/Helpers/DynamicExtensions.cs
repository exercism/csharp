using System.Collections;

namespace Exercism.CSharp.Helpers
{
    public static class DynamicExtensions
    {
        public static bool IsEmptyEnumerable(this object value)
        {   
            if (value is string)
                return false;
            
            return value is IEnumerable enumerable && enumerable.GetEnumerator().MoveNext() == false;
        }
    }
}