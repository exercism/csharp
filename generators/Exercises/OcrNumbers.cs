using System;
using System.Collections;
using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class OcrNumbers : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is int && data.Expected <= 0 ? typeof(ArgumentException) : null;
            data.Input["rows"] = ToDigitStringRepresentation(data.Input["rows"]);
            data.Expected = data.Expected.ToString();
            data.UseVariableForTested = true;
            data.UseVariablesForInput = true;
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
