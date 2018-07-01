using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string Array<T>(IEnumerable<T> elements) =>
            elements.Any()
                ? $"new[] {{ {string.Join(", ", elements.Cast<object>().Select(Object))} }}"
                : $"Array.Empty<{typeof(T).ToFriendlyName()}>()";

        public string MultidimensionalArray(int[,] multidimensionalArray)
        {
            IEnumerable<T> SliceRow<T>(T[,] array, int row)
            {
                for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
                {
                    yield return array[row, i];
                }
            }
            
            return multidimensionalArray.GetLength(0) > 0
                ? $"new[,]\r\n{{\r\n    {string.Join(",\r\n    ", System.Linq.Enumerable.Range(0, multidimensionalArray.GetUpperBound(0) + 1).Select(x => ToNestedArray(SliceRow(multidimensionalArray, x))))}\r\n}}"
                : "new int[,] { }";
        }

        public IEnumerable<string> MultiLineEnumerable(IEnumerable<string> enumerable, string name,
            string constructor = null)
            => MultiLineVariable(enumerable.Prepend("{").Append("}"), name, constructor);
        
        private string ToNestedArray<T>(IEnumerable<T> enumerable) =>
            enumerable.Any() ? $"{{ {string.Join(", ", enumerable)} }}" : string.Empty;
    }
}