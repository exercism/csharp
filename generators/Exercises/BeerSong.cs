using Generators.Input;

namespace Generators.Exercises
{
    public class BeerSong : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
                canonicalDataCase.UseVariableForExpected = true;
        }
    }
}