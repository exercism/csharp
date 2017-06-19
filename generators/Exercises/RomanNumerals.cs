using Generators.Output;

namespace Generators.Exercises
{
    public class RomanNumerals : EqualityExercise
    {
        public RomanNumerals()
        {
            Options.TestedMethodType = TestedMethodType.Extension;

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Property = "ToRoman";
                canonicalDataCase.Description = "Number_" + canonicalDataCase.Description;
            }
        }
    }
}