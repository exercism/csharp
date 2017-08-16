using Generators.Input;

namespace Generators.Exercises
{
    public class Luhn : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.Property = "IsValid";
        }
    }
}
