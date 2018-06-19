using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class NucleotideCount : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            if (((Dictionary<string, object>) canonicalDataCase.Expected).ContainsKey("error")) 
                return;

            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.SetConstructorInputParameters("strand");
            canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key[0], kv => int.Parse($"{kv.Value}"));

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Dictionary<char, int>).Namespace };

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            return testMethodBody.Data.UseVariableForExpected 
                ? RenderEqualBodyAssert(testMethodBody) 
                : RenderThrowsBodyAssert(testMethodBody);
        }

        private static IEnumerable<string> RenderEqualBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Equal(expected, sut.{{ TestedMethodName }});";

            var templateParameters = new
            {
                TestedMethodName = testMethodBody.Data.CanonicalDataCase.Property.ToTestedMethodName()
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        private static IEnumerable<string> RenderThrowsBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Throws<InvalidNucleotideException>(() => new NucleotideCount(""{{ Input }}""));";

            var templateParameters = new
            {
                Input = testMethodBody.Data.CanonicalDataCase.Input["strand"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}
