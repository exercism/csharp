using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class ScaleGenerator : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod) => testMethod.UseVariableForExpected = true;
    }
}