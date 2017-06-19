using Generators.Output;

namespace Generators.Exercises
{
    public class RomanNumerals : Exercise
    {
        public RomanNumerals()
        {
            Options.TestedMethodFormat = TestedMethodFormat.Extension;

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Property = "ToRoman";
                canonicalDataCase.Description = "Number_" + canonicalDataCase.Description;
            }
        }
    }
}