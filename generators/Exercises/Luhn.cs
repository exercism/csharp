using Generators.Output;

namespace Generators.Exercises
{
    public class Luhn : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Property = "IsValid";
        }
    }
}
