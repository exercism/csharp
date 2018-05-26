using Generators.Input;

namespace Generators.Exercises
{
    public class Markdown : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }

        protected override bool ShouldSkipTestMethod(CanonicalDataCase canonicalDataCase, int index) => false;
    }
}