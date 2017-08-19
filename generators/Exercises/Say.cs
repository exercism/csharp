using Generators.Input;

namespace Generators.Exercises
{
    public class Say : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                // Rename the property to avoid it being considered a constructor
                if (canonicalDataCase.Property == "say")
                {
                    canonicalDataCase.Property = "in_english";
                }

                if (canonicalDataCase.Expected is long)
                {
                    canonicalDataCase.Expected = canonicalDataCase.Expected.ToString();
                }
            }
        }
    }
}