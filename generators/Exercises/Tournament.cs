using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Tournament : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Static;
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Properties["input"] = ToMultiLineString(canonicalDataCase.Properties["input"]);
                canonicalDataCase.Expected = ToMultiLineString(canonicalDataCase.Expected);
            }
        }

        protected override HashSet<string> AddAdditionalNamespaces()
        {
            return new HashSet<string>
            {
                typeof(System.String).Namespace,
                typeof(System.IO.Stream).Namespace,
                typeof(System.Text.UTF8Encoding).Namespace
            };
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            string template = @"Assert.Equal(expected, RunTally(input).Trim());";
            return TemplateRenderer.RenderInline(template, new { });
        }

        private UnescapedValue ToMultiLineString(string[] input)
        {
            const string template = @"{% if input.size == 0 %}string.Empty{% else %}{% for item in {{input}} %}{% if forloop.length == 1 %}""{{item}}""{% break %}{% endif %}""{{item}}""{% if forloop.last == false %} + Environment.NewLine +{% endif %}
               {% endfor %}.Trim(){% endif %}";
        
            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }

        protected override string[] RenderAdditionalMethods()
        {
            var methods = @"
private string RunTally(string input)
{
    var encoding = new UTF8Encoding();

    using (var inStream = new MemoryStream(encoding.GetBytes(input)))
    {
        using (var outStream = new MemoryStream())
        {
            Tournament.Tally(inStream, outStream);
            return encoding.GetString(outStream.ToArray());
        }
    }
}";
            return methods.Split("", System.StringSplitOptions.None);
        }


    }
}
