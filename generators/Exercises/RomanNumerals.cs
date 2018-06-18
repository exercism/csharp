using Generators.Input;

namespace Generators.Exercises
{
    public class RomanNumerals : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.TestedMethodType = TestedMethodType.Extension;
            canonicalDataCase.Property = "ToRoman";
        }
    }
}