using Generators.Output;

namespace Generators.Exercises
{
    public class TwoFer : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Property = "Name";
        }
    }
}