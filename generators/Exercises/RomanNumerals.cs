using Generators.Input;

namespace Generators.Exercises
{
    public class RomanNumerals : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Extension;
                canonicalDataCase.Property = "ToRoman";
            }
        }
    }
}