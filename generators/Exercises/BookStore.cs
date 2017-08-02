using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class BookStore : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Input = new Dictionary<string, object>
                {
                    ["input"] = canonicalDataCase.Input["basket"].ConvertToEnumerable<int>()
                };
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
    }
}