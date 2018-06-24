using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Leap : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "IsLeapYear";
        }
    }
}