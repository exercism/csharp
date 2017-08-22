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
                canonicalDataCase.Input.Remove("subject");
                canonicalDataCase.Input["candidates"] = canonicalDataCase.Input["candidates"].ConvertToEnumerable<string>();
                canonicalDataCase.Expected = canonicalDataCase.Expected.ConvertToEnumerable<string>();

                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
            }
        }
    }
}