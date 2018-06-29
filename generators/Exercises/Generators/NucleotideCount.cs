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

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            return method.Data.UseVariableForExpected
                ? RenderEqualAssert(method)
                : RenderThrowsAssert(method);
        }

        private static string RenderEqualAssert(TestMethod method)
        {
            const string template = @"Assert.Equal(expected, sut.{{ TestedMethodName }});";

            var templateParameters = new
            {
                TestedMethodName = method.Data.Property.ToTestedMethodName()
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private static string RenderThrowsAssert(TestMethod method)
        {
            const string template = @"Assert.Throws<InvalidNucleotideException>(() => new NucleotideCount(""{{ Input }}""));";

            var templateParameters = new
            {
                Input = method.Data.Input["strand"]
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}
