using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class BinarySearch : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["array"] = canonicalDataCase.Input["array"].ConvertToEnumerable<int>()
                };
                canonicalDataCase.Input.Remove("array");

                canonicalDataCase.UseVariablesForConstructorParameters = true;
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
            }
        }
    }
}