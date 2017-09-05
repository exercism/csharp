using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class Anagram : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["subject"] = canonicalDataCase.Input["subject"]
                };

                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}