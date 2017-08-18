using Generators.Input;

namespace Generators.Exercises
{
    public class RunLengthEncoding : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                // Prefix the test name with encode/decode because both functions are tested with the same cases
                canonicalDataCase.Description = $"{canonicalDataCase.Property} {canonicalDataCase.Description}";
            }
        }
    }
}