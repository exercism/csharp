using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string List<T>(List<T> objects) =>
            objects.Any()
                ? $"new List<{typeof(T).ToBuiltInTypeName()}> {{ {string.Join(", ", objects.Cast<object>().Select(Object))} }}"
                : $"new List<{typeof(T).ToBuiltInTypeName()}>()";
    }
}