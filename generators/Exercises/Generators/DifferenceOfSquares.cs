using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class DifferenceOfSquares : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = $"Calculate{testMethod.TestedMethod}";
        }
    }
}
