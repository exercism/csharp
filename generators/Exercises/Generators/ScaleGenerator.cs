using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class ScaleGenerator : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
        }
    }
}