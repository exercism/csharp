using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class BookStore : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Input = new Dictionary<string, object>
                {
                    ["input"] = canonicalDataCase.Input["basket"]
                };
                canonicalDataCase.UseVariablesForInput = true;
            }
        }
    }
}