using Generators.Input;
using Generators.Output;
using System.Collections.Generic;
using System.Linq;

namespace Generators.Exercises
{
    public class NucleotideCount : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            if (!((Dictionary<string, object>)canonicalDataCase.Expected).ContainsKey("error"))
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.SetConstructorInputParameters("strand");
                canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
            }
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key[0], kv => int.Parse($"{kv.Value}"));

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Dictionary<char, int>).Namespace };

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.UseVariableForExpected)
            {
                return RenderEqualBodyAssert(testMethodBody);
            }

            return RenderThrowsBodyAssert(testMethodBody);
        }

        private IEnumerable<string> RenderEqualBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Equal(expected, sut.{{ TestedMethodName }});";

            var templateParameters = new
            {
                TestedMethodName = testMethodBody.CanonicalDataCase.Property.ToTestedMethodName()
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        private IEnumerable<string> RenderThrowsBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Throws<InvalidNucleotideException>(() => new NucleotideCount(""{{ Input }}""));";

            var templateParameters = new
            {
                Input = testMethodBody.CanonicalDataCase.Input["strand"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}
