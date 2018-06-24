using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Minesweeper : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;

            data.Input["minefield"] = ToMultiLineString(data.Input["minefield"]);
            data.Expected = ToMultiLineString(data.Expected);
        }

        private static UnescapedValue ToMultiLineString(JArray input) => new UnescapedValue("Array.Empty<string>()");

        private static UnescapedValue ToMultiLineString(IEnumerable<string> input)
        {
            const string template =
@"new string[] 
{ 
    {% if input.size > 0 %}{% for item in {{input}} %}{% if forloop.length == 1 %}""{{item}}""{% break %}{% endif %}""{{item}}""{% if forloop.last == false %},{% else %}{{string.Empty}}{% endif %}
    {% endfor %}{% endif %} 
}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}
