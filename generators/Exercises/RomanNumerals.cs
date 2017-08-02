using Generators.Input;

namespace Generators.Exercises
{
    public class RomanNumerals : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Extension;
                canonicalDataCase.Property = "ToRoman";
                canonicalDataCase.Description = "Number_" + canonicalDataCase.Description;
            }
        }
    }
}