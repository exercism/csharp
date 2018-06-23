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
        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            return testMethodBody.Data.Property == "consistency"
                ? RenderConsistencyToAssert(testMethodBody)
                : testMethodBody.Assert;
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