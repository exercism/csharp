using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class RailFenceCipher : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["rails"] = canonicalDataCase.Properties["rails"]
                };
                canonicalDataCase.Input.Remove("rails");
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}