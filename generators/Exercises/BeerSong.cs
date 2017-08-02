using Generators.Input;

namespace Generators.Exercises
{
    public class BeerSong : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.UseVariableForExpected = true;
        }
    }
}