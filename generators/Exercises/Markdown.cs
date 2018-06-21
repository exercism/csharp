using Generators.Output;

namespace Generators.Exercises
{
    public class Markdown : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }

        protected override TestMethod CreateTestMethod(TestData canonicalDataCase, int index)
        {
            var testMethod = base.CreateTestMethod(canonicalDataCase, index);
            testMethod.Skip = false;

            return testMethod;
        }
    }
}