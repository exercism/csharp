using Generators.Output;

namespace Generators.Exercises
{
    public class ScaleGenerator : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariableForExpected = true;
        }
    }
}