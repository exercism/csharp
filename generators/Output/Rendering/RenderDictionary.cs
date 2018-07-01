using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string Dictionary<TKey, TValue>(IDictionary<TKey, TValue> dict) =>
            dict.Count == 0
                ? $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Object(key)}] = {Object(dict[key])}"))} }}"
                : $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>";
    }
}