using Generators.Output;

namespace Generators.Exercises
{
    public class RomanNumerals : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethodType = TestedMethodType.Extension;
            data.Property = "ToRoman";
        }
    }
}