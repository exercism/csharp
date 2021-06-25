using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Scale : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
        }
    }
}