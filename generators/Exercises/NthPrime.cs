using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class NthPrime : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is bool ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}