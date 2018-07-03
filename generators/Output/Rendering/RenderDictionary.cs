using System;
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
                : $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>{Environment.NewLine}{{{Environment.NewLine}{string.Join($",{Environment.NewLine}", dict.Select(KeyValueAssignment).Select(assignment => assignment.Indent()))}{Environment.NewLine}}}";
        
        private string KeyValueAssignment<TKey, TValue>(KeyValuePair<TKey, TValue> kv) => $"[{Object(kv.Key)}] = {Object(kv.Value)}";
    }
}