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
            => Variable(kv.Key.ToVariableName(), ObjectMultiLine(kv.Value));

        public string Variable(string name, string value) => $"var {name} = {value};";
    }
}