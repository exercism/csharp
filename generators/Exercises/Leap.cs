using Generators.Output;

namespace Generators.Exercises
{
    public class Leap : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.Property = "IsLeapYear";
        }
    }
}