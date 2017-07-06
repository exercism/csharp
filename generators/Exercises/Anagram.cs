using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Anagram : Exercise
    {
        public Anagram()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["subject"] = canonicalDataCase.Input["subject"]
                };
                canonicalDataCase.Input.Remove("subject");
                canonicalDataCase.Input["candidates"] = ((JArray)canonicalDataCase.Input["candidates"]).Values<string>();
                canonicalDataCase.Expected = ((JArray)canonicalDataCase.Expected).Values<string>();

                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
            }
        }
    }
}