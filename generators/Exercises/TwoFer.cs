using Generators.Output;

namespace Generators.Exercises
{
    public class TwoFer : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.Property = "Name";
        }
    }
}