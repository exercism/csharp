using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;

namespace Generators.Exercises
{
    public class Alphametics : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariableForTested = true;

                if (canonicalDataCase.Expected == null)
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
                else
                    canonicalDataCase.Expected = ConvertExpected(canonicalDataCase);
            }
        }

        private static dynamic ConvertExpected(CanonicalDataCase canonicalDataCase) 
            => ((Dictionary<string, object>)canonicalDataCase.Expected).ToDictionary(kv => kv.Key[0], kv => int.Parse(kv.Value.ToString()));

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string> { typeof(Dictionary<char, int>).Namespace };
    }
}