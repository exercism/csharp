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
                : $"new[,] {{ {string.Join(", ", elements.Rows().Select(RenderRow))} }}";

            string RenderRow(T[] row) => $"{{ {string.Join(", ", row.Cast<object>().Select(Object))} }}";
        }

        public IEnumerable<string> MultiLineEnumerable(IEnumerable<string> enumerable, string name,
            string constructor = null)
            => MultiLineVariable(enumerable.Prepend("{").Append("}"), name, constructor);
    }
}