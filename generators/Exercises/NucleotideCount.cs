using Generators.Input;
using Generators.Output;
using System.Collections.Generic;
using System.Linq;

namespace Generators.Exercises
{
    class NucleotideCount : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (!((Dictionary<string, object>)canonicalDataCase.Expected).ContainsKey("error"))
                {
                    canonicalDataCase.UseVariableForExpected = true;
                    canonicalDataCase.SetConstructorInputParameters("strand");
                    canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
                }
            }
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key[0], kv => int.Parse($"{kv.Value}"));

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string>() { typeof(Dictionary<char, int>).Namespace };

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.UseVariableForExpected)
            {
                return RenderEqualBodyAssert(testMethodBody);
            }
            return RenderThrowsBodyAssert(testMethodBody);
        }

        private string RenderEqualBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Equal(expected, sut.{{ TestedMethodName }});";

            var templateParameters = new
            {
                TestedMethodName = NameExtensions.ToTestedMethodName(testMethodBody.CanonicalDataCase.Property)
            }

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private string RenderThrowsBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Throws<InvalidNucleotideException>(() => new NucleotideCount(""{{ Input }}""));";

            var templateParameters = new
            {
                Input = testMethodBody.CanonicalDataCase.Input["strand"]
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}
