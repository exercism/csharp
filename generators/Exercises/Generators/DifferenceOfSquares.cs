using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class DifferenceOfSquares : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = $"Calculate{data.TestedMethod}";
        }
    }
}
