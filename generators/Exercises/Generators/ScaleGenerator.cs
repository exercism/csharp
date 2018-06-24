using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class ScaleGenerator : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
        }
    }
}