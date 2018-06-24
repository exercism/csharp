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

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Skip = false;
        }
    }
}