using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                // Prefix the test name with encode/decode because both functions are tested with the same cases
                canonicalDataCase.Description = $"{canonicalDataCase.Property} {canonicalDataCase.Description}";
            }
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
                ExerciseName = testMethodBody.CanonicalData.Exercise.ToTestedClassName()
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }
    }
}