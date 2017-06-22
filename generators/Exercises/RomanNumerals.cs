namespace Generators.Exercises
{
    public class RomanNumerals : Exercise
    {
        public RomanNumerals()
        {
            Configuration.TestedMethodType = TestedMethodType.Extension;

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Property = "ToRoman";
                canonicalDataCase.Description = "Number_" + canonicalDataCase.Description;
            }
        }
    }
}