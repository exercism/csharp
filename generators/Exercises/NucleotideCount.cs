using System.Collections.Generic;
using System.Linq;
using Generators.Output;

namespace Generators.Exercises
{
    public class NucleotideCount : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            if (((Dictionary<string, object>)data.Expected).ContainsKey("error"))
                return;

            data.UseVariableForExpected = true;
            data.SetConstructorInputParameters("strand");
            data.Expected = ConvertExpected(data.Expected);
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
                TestedMethodName = testMethodBody.Data.Property.ToTestedMethodName()
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        private static IEnumerable<string> RenderThrowsBodyAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Throws<InvalidNucleotideException>(() => new NucleotideCount(""{{ Input }}""));";

            var templateParameters = new
            {
                Input = testMethodBody.Data.Input["strand"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}
