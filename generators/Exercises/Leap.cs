using Generators.Output;

namespace Generators.Exercises
{
    public class Leap : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "IsLeapYear";
        }
    }
}