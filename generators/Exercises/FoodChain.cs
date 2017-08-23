using Generators.Input;

namespace Generators.Exercises
{
    public class FoodChain : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Expected = canonicalDataCase.Expected.ConvertMultiLineString();
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}