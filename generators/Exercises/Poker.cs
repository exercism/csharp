using Generators.Input;

namespace Generators.Exercises
{
    public class Poker : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariableForTested = true;

                canonicalDataCase.Expected = canonicalDataCase.Expected.ConvertToEnumerable<string>();
                canonicalDataCase.Input["input"] = canonicalDataCase.Input["input"].ConvertToEnumerable<string>();
            }
        }
    }
}
