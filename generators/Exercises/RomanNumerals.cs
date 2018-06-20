using Generators.Output;

namespace Generators.Exercises
{
    public class RomanNumerals : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.TestedMethodType = TestedMethodType.Extension;
            data.Property = "ToRoman";
        }
    }
}