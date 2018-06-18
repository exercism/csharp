using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Description = $"{canonicalDataCase.Property} {canonicalDataCase.Description}";
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.CanonicalDataCase.Property == "consistency")
            {
                return RenderConsistencyToAssert(testMethodBody);
            }

            return base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static string RenderConsistencyToAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Equal(""{{ExpectedOutput}}"", {{ExerciseName}}.Decode({{ExerciseName}}.Encode(""{{ExpectedOutput}}"")));";

            var templateParameters = new
            {
                ExpectedOutput = testMethodBody.CanonicalDataCase.Expected,
                ExerciseName = testMethodBody.CanonicalDataCase.Exercise.ToTestedClassName()
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}