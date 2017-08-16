using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class Transpose : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Property = "String";
                canonicalDataCase.Input = new Dictionary<string, object>
                {
                    ["input"] = canonicalDataCase.Input["input"].ConvertMultiLineString()
                };
                canonicalDataCase.Expected = canonicalDataCase.Expected.ConvertMultiLineString();
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}