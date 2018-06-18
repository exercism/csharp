using System;
using System.Collections;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class OcrNumbers : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {   
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is int && canonicalDataCase.Expected <= 0 ? typeof(ArgumentException) : null;
            canonicalDataCase.Input["rows"] = ToDigitStringRepresentation(canonicalDataCase.Input["rows"]);
            canonicalDataCase.Expected = canonicalDataCase.Expected.ToString();
            canonicalDataCase.UseVariableForTested = true;
            canonicalDataCase.UseVariablesForInput = true;
        }

        private static UnescapedValue ToDigitStringRepresentation(IEnumerable input)
        {
            const string template = @" {% for item in {{input}} %}{% if forloop.first == true %}""{{item}}"" + ""\n"" +{% continue %}{% endif %}
             ""{{item}}""{% if forloop.last == false %} + ""\n"" +{% endif %}{% endfor %}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}
