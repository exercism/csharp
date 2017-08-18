using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class PhoneNumber : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.Expected = canonicalDataCase.Expected ?? new UnescapedValue("null");
            }
        }
    }
}