using Generators.Output;

namespace Generators.Exercises
{
    public class Markdown : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }

        protected override TestMethod CreateTestMethod(TestMethodBodyData canonicalDataCase, int index)
        {
            var testMethod = base.CreateTestMethod(canonicalDataCase, index);
            testMethod.Skip = false;

            return testMethod;
        }
    }
}