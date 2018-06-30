using System.Collections.Generic;
using System.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string Dictionary(IDictionary<string, object> dict) =>
            string.Join(", ", dict.Values.Select(Object));

        public string Dictionary(IDictionary<char, int> dict) =>
            $"new Dictionary<char, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Char(key)}] = {Int(dict[key])}"))} }}";

        public string Dictionary(IDictionary<string, int> dict) =>
            $"new Dictionary<string, int> {{ {string.Join(", ", dict.Keys.Select(key => $"[{String(key)}] = {Int(dict[key])}"))} }}";

        public string Dictionary(IDictionary<int, string[]> dict) =>
            $"new Dictionary<int, string[]> {{ {string.Join(", ", dict.Keys.Select(key => $"[{Int(key)}] = {Array(dict[key])}"))} }}";
    }
}