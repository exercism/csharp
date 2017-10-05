using System;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class OcrNumbers : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ExceptionThrown = (canonicalDataCase.Expected is long && canonicalDataCase.Expected <= 0) ? typeof(ArgumentException) : null;
                canonicalDataCase.Properties["input"] = ToDigitStringRepresentation(canonicalDataCase.Properties["input"]);
                canonicalDataCase.Expected = canonicalDataCase.Expected.ToString();
                canonicalDataCase.UseVariableForTested = true;
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
       
        private UnescapedValue ToDigitStringRepresentation(string[] input)
        {
            const string template = @" {% for item in {{input}} %}{% if forloop.first == true %}""{{item}}"" + ""\n"" +{% continue %}{% endif %}
             ""{{item}}""{% if forloop.last == false %} + ""\n"" +{% endif %}{% endfor %}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }
    }
}
