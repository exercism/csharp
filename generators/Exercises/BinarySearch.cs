using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class BinarySearch : Exercise
    {
        public BinarySearch()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["array"] = ((JArray)canonicalDataCase.Input["array"]).Values<int>()
                };
                canonicalDataCase.Input.Remove("array");

                canonicalDataCase.UseVariablesForConstructorParameters = true;
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
            }
        }
    }
}