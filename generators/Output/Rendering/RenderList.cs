using System.Collections.Generic;
using System.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string List(List<int> ints) =>
            ints.Any() ? $"new List<int> {{ {string.Join(", ", ints.Select(Int))} }}" : "new List<int>()";

        public string List(List<object> objects) =>
            objects.Any()
                ? $"new List<object> {{ {string.Join(", ", objects.Select(Object))} }}"
                : "new List<object>()";
    }
}