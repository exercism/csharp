using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
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
            const string template = @"Assert.Equal(""{{ExpectedOutput}}"", {{ExerciseName}}.Decode({{ExerciseName}}.Encode(""{{ExpectedOutput}}"")));";

            var templateParameters = new
            {
                ExpectedOutput = testMethodBody.Data.Expected,
                ExerciseName = testMethodBody.Data.Exercise.ToTestedClassName()
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}