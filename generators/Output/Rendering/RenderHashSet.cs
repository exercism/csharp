using System.Collections.Generic;
using System.Linq;

using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    internal partial class Render
    {
        public string HashSet<T>(HashSet<T> elements) =>
            elements.Any()
                ? $"new HashSet<{typeof(T).ToFriendlyName()}>{CollectionInitializer(elements)}"
                : $"new HashSet<{typeof(T).ToFriendlyName()}>()";
    }
}
