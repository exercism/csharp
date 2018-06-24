using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
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