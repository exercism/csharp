using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Transpose : Exercise
    {
        public Transpose()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Property = "String";
                canonicalDataCase.Input = new Dictionary<string, object>
                {
                    ["input"] = string.Join("\n", (JArray)canonicalDataCase.Input["input"])
                };
                canonicalDataCase.Expected = string.Join("\n", (JArray)canonicalDataCase.Expected);
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}