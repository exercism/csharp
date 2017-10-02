using System.Text;
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
                canonicalDataCase.Properties["input"] = ToDigit(canonicalDataCase.Properties["input"]);
            }
        }

        protected override string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            const string template = @"var converted = {{MethodInvocation}};";

            var templateParameters = new
            {
                MethodInvocation = testMethodBody.Data.TestedMethodInvocation
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Equal(""{{Expected}}"", converted);";

            var templateParameters = new { Expected = testMethodBody.CanonicalDataCase.Expected };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private UnescapedValue ToDigit(string[] input)
        {
            const string template = @"{% for item in {{input}} %}
""{{item}}""{% if forloop.last == false %} + ""\n"" +{% endif %}{% endfor %}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }
    }
}
