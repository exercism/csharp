using Generators.Input;

namespace Generators.Exercises
{
    public class SecretHandshake : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Expected = canonicalDataCase.Expected.ConvertToEnumerable<string>();
            }
        }
    }
}