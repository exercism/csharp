using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string Array<T>(T[] elements) =>
            elements.Any()
                ? $"new[] {{ {string.Join(", ", elements.Cast<object>().Select(Object))} }}"
                : $"Array.Empty<{typeof(T).ToFriendlyName()}>()";
  
        public string Array<T>(T[,] elements)
        {
            return elements.Length == 0 
                ? $"new {typeof(T).ToFriendlyName()}[,] {{ }}" 
                : $"new[,] {{ {string.Join(", ", Rows(elements).Select(Row))} }}";

            string Row(T[] row) => $"{{ {string.Join(", ", row.Cast<object>().Select(Object))} }}";
        }

        private static T[][] Rows<T>(T[,] elements)
        {
            return Enumerable.Range(0, elements.GetLength(0))
                .Select(Row)
                .ToArray();
            
            T[] Row(int row) => Enumerable.Range(0, elements.GetLength(1)).Select(col => elements[row, col]).ToArray();
        }

        public IEnumerable<string> MultiLineEnumerable(IEnumerable<string> enumerable, string name,
            string constructor = null)
            => MultiLineVariable(enumerable.Prepend("{").Append("}"), name, constructor);
    }
}