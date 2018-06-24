using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwoFer : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "Name";
        }
    }
}