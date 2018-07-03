using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public IEnumerable<string> Variables(IDictionary<string, object> dict)
            => dict.Select(Variable).ToArray();

        private string Variable(KeyValuePair<string, object> kv) 
            => Variable(kv.Key.ToVariableName(), kv.Value);

        public string Variable(string name, object val)
        {
            switch (val)
            {
                case MultiLineString multiLineValue:
                    return $"var {name} = {StringMultiLine(multiLineValue)};";
                case IEnumerable<string> strings:
                    if (!strings.Any())
                    {
                        return $"var {name} = Array.Empty<string>();";
                    }

                    return string.Join(Environment.NewLine, MultiLineEnumerable(
                        strings.Select((str, i) => String(str) + (i < strings.Count() - 1 ? "," : "")), name, "new[]"));
                default:
                    if (IsDictionary(val))
                        return $"var {name} = {DictionaryMultiLine((dynamic)val)};";

                    return $"var {name} = {Object(val)};";
            }
        }

        public IEnumerable<string> MultiLineVariable(IEnumerable<string> enumerable, string name, string constructor = null)
            => enumerable.Select(line => line == "{" || line == "}" ? line : line.Indent()).AddTrailingSemicolon().Prepend($"var {name} = {constructor}").ToArray();
    }
}