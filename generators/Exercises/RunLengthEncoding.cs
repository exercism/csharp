using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Description = $"{data.Property} {data.Description}";
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            return testMethodBody.Data.Property == "consistency"
                ? RenderConsistencyToAssert(testMethodBody)
                : base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static IEnumerable<string> RenderConsistencyToAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Equal(""{{Expected}}"", {{TestedClassName}}.Decode({{TestedClassName}}.Encode(""{{Expected}}"")));";

            var templateParameters = new
            {
                testMethodBody.Data.Expected,
                TestedClassName = testMethodBody.Data.TestedClass
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}