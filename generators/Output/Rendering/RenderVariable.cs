using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public IEnumerable<string> Variables(IDictionary<string, object> dict)
            => dict.Keys.SelectMany(key => Variable(dict[key], key.ToVariableName())).ToArray();

        public IEnumerable<string> Variable(object val, string name)
        {
            switch (val)
            {
                case string str when str.Contains("\n"):
                    return MultiLineString(name, str);
                case MultiLineString multiLineValue when multiLineValue.ToString().Contains("\n"):
                    return MultiLineString(name, multiLineValue.ToString());
                case IEnumerable<string> strings:
                    if (!strings.Any())
                    {
                        return new[] {$"var {name} = Array.Empty<string>();"};
                    }

                    return MultiLineEnumerable(
                        strings.Select((str, i) => String(str) + (i < strings.Count() - 1 ? "," : "")), name, "new[]");
                case IDictionary<char, int> dict:
                    return MultiLineEnumerable(
                        dict.Keys.Select((key, i) =>
                            $"[{Char(key)}] = {Int(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name,
                        "new Dictionary<char, int>");
                case IDictionary<string, int> dict:
                    return MultiLineEnumerable(
                        dict.Keys.Select((key, i) =>
                            $"[{String(key)}] = {Int(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name,
                        "new Dictionary<string, int>");
                case IDictionary<int, string[]> dict:
                    return MultiLineEnumerable(
                        dict.Keys.Select((key, i) =>
                            $"[{Int(key)}] = {Array(dict[key])}" + (i < dict.Keys.Count - 1 ? "," : "")), name,
                        "new Dictionary<int, string[]>");
                default:
                    return new[] {$"var {name} = {Object(val)};"};
            }
        }

        public IEnumerable<string> MultiLineVariable(IEnumerable<string> enumerable, string name, string constructor = null)
            => enumerable.Select(line => line == "{" || line == "}" ? line : line.Indent()).AddTrailingSemicolon().Prepend($"var {name} = {constructor}").ToArray();
    }
}