using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RomanNumerals : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethodType = TestedMethodType.Extension;
            data.TestedMethod = "ToRoman";
        }
    }
}