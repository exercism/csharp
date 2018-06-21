using Generators.Output;

namespace Generators.Exercises
{
    public class ScaleGenerator : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
        }
    }
}