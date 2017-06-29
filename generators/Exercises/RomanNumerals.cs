namespace Generators.Exercises
{
    public class RomanNumerals : Exercise
    {
        public RomanNumerals()
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