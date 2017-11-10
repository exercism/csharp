using Generators.Input;

namespace Generators.Exercises
{
    public class IsbnVerifier : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "IsValid";
            }
        }
    }
}
