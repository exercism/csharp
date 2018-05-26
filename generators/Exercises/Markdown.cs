using Generators.Input;
using Generators.Output;

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

        protected override TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethod = base.CreateTestMethod(canonicalDataCase, index);
            testMethod.Skip = false;

            return testMethod;
        }
    }
}