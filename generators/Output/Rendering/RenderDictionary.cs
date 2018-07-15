using System.Collections.Generic;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string Dictionary<TKey, TValue>(IDictionary<TKey, TValue> dict) =>
            dict.Count == 0
                ? $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>()"
                : $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>{CollectionInitializer(dict, KeyValueAssignment)}";

        public string DictionaryMultiLine<TKey, TValue>(IDictionary<TKey, TValue> dict) =>
            dict.Count == 0
                ? $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>()"
                : $"new Dictionary<{typeof(TKey).ToFriendlyName()}, {typeof(TValue).ToFriendlyName()}>{MultiLineCollectionInitializer(dict, KeyValueAssignment)}";
        
        private string KeyValueAssignment<TKey, TValue>(KeyValuePair<TKey, TValue> kv) => $"[{Object(kv.Key)}] = {Object(kv.Value)}";
    }
}