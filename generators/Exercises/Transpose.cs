using System.Collections.Generic;
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
                canonicalDataCase.Input = new Dictionary<string, object>
                {
                    ["input"] = Convert.ToMultiLineString(canonicalDataCase.Input["input"])
                };
                canonicalDataCase.Expected = Convert.ToMultiLineString(canonicalDataCase.Expected);
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}