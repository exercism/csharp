using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class OcrNumbers : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ExceptionThrown = (canonicalDataCase.Expected is int && canonicalDataCase.Expected <= 0) ? typeof(ArgumentException) : null;
                canonicalDataCase.Input["rows"] = ToDigitStringRepresentation(canonicalDataCase.Input["rows"]);
                canonicalDataCase.Expected = canonicalDataCase.Expected.ToString();
                canonicalDataCase.UseVariableForTested = true;
                canonicalDataCase.UseVariablesForInput = true;
            }
        }

        private UnescapedValue ToMultiLineString(JArray input)
        {
            return new UnescapedValue("Array.Empty<string>()");
        }

        private UnescapedValue ToDigitStringRepresentation(string[] input)
        {
            const string template = @" {% for item in {{input}} %}{% if forloop.first == true %}""{{item}}"" + ""\n"" +{% continue %}{% endif %}
             ""{{item}}""{% if forloop.last == false %} + ""\n"" +{% endif %}{% endfor %}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}
