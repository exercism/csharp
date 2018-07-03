using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string Dictionary<TKey, TValue>(IDictionary<TKey, TValue> dict) =>
            dict.Count == 0
                ? $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>()"
                : $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}> {{ {string.Join(", ", dict.Select(KeyValueAssignment))} }}";

        public string DictionaryMultiLine<TKey, TValue>(IDictionary<TKey, TValue> dict) =>
            dict.Count == 0
                ? $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>()"
                : $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>\n{{\n{string.Join(",\n", dict.Select(KeyValueAssignment).Select(assignment => assignment.Indent()))}\n}}";
        
        private string KeyValueAssignment<TKey, TValue>(KeyValuePair<TKey, TValue> kv) => $"[{Object(kv.Key)}] = {Object(kv.Value)}";
    }
}