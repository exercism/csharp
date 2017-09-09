using Generators.Input;

namespace Generators.Exercises
{
    public class House : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Expected = Convert.ToMultiLineString(canonicalDataCase.Expected);
            }
        }
    }
}