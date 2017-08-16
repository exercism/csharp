using Generators.Input;

namespace Generators.Exercises
{
    public class Leap : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.Property = "IsLeapYear";
        }
    }
}