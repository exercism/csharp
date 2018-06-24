using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Luhn : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "IsValid";
        }
    }
}
