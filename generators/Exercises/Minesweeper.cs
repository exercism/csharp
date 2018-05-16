using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Minesweeper : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;

                canonicalDataCase.Input["minefield"] = ToMultiLineString(canonicalDataCase.Input["minefield"]);
                canonicalDataCase.Expected = ToMultiLineString(canonicalDataCase.Expected);
            }
        }

        private UnescapedValue ToMultiLineString(JArray input)
        {
            return new UnescapedValue("new string[0]");
        }

        private UnescapedValue ToMultiLineString(IEnumerable<string> input)
        {
            const string template =
@"new string[] 
{ 
    {% if input.size > 0 %}{% for item in {{input}} %}{% if forloop.length == 1 %}""{{item}}""{% break %}{% endif %}""{{item}}""{% if forloop.last == false %},{% else %}{{string.Empty}}{% endif %}
    {% endfor %}{% endif %} 
}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string> { typeof(Array).Namespace };
    }
}
