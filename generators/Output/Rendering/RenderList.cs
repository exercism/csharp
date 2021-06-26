using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    internal partial class Render
    {   
        public string List<T>(List<T> elements) =>
            elements.Any()
                ? $"new List<{typeof(T).ToFriendlyName()}>{CollectionInitializer(elements)}"
                : $"new List<{typeof(T).ToFriendlyName()}>()";
    }
}