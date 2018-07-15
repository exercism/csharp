using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public IEnumerable<string> Variables(IDictionary<string, object> variables)
            => variables.Select(Variable).ToArray();

        private string Variable(KeyValuePair<string, object> variable) 
            => Variable(variable.Key.ToVariableName(), ObjectMultiLine(variable.Value));

        public string Variable(string name, string value) => $"var {name} = {value};";
    }
}