using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string Array(IEnumerable<int> ints) =>
            ints.Any() ? $"new[] {{ {string.Join(", ", ints)} }}" : "Array.Empty<int>()";
        
        public string Array(IEnumerable<string> strings) =>
            strings.Any() ? $"new[] {{ {string.Join(", ", strings.Select(String))} }}" : "Array.Empty<string>()";

        public string Array(IEnumerable<object> objects) =>
            objects.Any() ? $"new[] {{ {string.Join(", ", objects.Select(Object))} }}" : "Array.Empty<object>()";
        
        public string Array(JArray jArray) =>
            $"new[] {{ {string.Join(", ", jArray.Select(Array))} }}";
        
        public string Array(IEnumerable<UnescapedValue> unescapedValues) =>
            $"new[] {{ {string.Join(", ", unescapedValues.Select(Object))} }}";

        public string Array(IEnumerable<Tuple<string, object>> tuples) =>
            $"new[] {{ {string.Join(", ", tuples.Select(Tuple))} }}";

        public string Array(IEnumerable<ValueTuple<int, int>> tuples) => tuples.Any() ?
            $"new[] {{ {string.Join(", ", tuples)} }}" : "Array.Empty<ValueTuple<int,int>>()";

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