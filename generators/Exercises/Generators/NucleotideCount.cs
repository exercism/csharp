using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
{
    public class NucleotideCount : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (((Dictionary<string, object>)data.Expected).ContainsKey("error"))
                return;

            data.UseVariableForExpected = true;
            data.SetConstructorInputParameters("strand");
            data.Expected = ConvertExpected(data.Expected);
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key[0], kv => int.Parse($"{kv.Value}"));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<char, int>).Namespace);
        }

        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody body)
        {
            return body.Data.UseVariableForExpected
                ? RenderEqualBodyAssert(body)
                : RenderThrowsBodyAssert(body);
        }

        private static IEnumerable<string> RenderEqualBodyAssert(TestMethodBody body)
        {
            const string template = @"Assert.Equal(expected, sut.{{ TestedMethodName }});";

            var templateParameters = new
            {
                TestedMethodName = body.Data.Property.ToTestedMethodName()
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        private static IEnumerable<string> RenderThrowsBodyAssert(TestMethodBody body)
        {
            const string template = @"Assert.Throws<InvalidNucleotideException>(() => new NucleotideCount(""{{ Input }}""));";

            var templateParameters = new
            {
                Input = body.Data.Input["strand"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}
