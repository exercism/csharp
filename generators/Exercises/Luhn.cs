using Generators.Output;

namespace Generators.Exercises
{
    public class Luhn : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.Property = "IsValid";
        }
    }
}
