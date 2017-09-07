using System;
using System.Collections.Generic;
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
                    canonicalDataCase.Expected = canonicalDataCase.Expected.ToObject<Dictionary<char, int>>();
            }
        }

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string> { typeof(Dictionary<char, int>).Namespace };
    }
}