using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Minesweeper : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;

                canonicalDataCase.Properties["input"] = ToMultiLineString(canonicalDataCase.Properties["input"]);
                canonicalDataCase.Properties["expected"] = ToMultiLineString(canonicalDataCase.Properties["expected"]);
            }
        }

        private UnescapedValue ToMultiLineString(string[] input)
        {
            const string template = 
@"new string[] 
{ 
    {% if input.size > 0 %}{% for item in {{input}} %}{% if forloop.length == 1 %}""{{item}}""{% break %}{% endif %}""{{item}}""{% if forloop.last == false %},{% else %}{{string.Empty}}{% endif %}
    {% endfor %}{% endif %} 
}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }
    }
}
