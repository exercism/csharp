using Generators.Input;

namespace Generators.Exercises
{
    public class Transpose : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "String";
                canonicalDataCase.Properties["input"] = Convert.ToMultiLineString(canonicalDataCase.Properties["input"]);
                canonicalDataCase.Expected = Convert.ToMultiLineString(canonicalDataCase.Expected);

                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}