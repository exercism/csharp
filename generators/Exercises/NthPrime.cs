using System;

namespace Generators.Exercises
{
    public class NthPrime : Exercise
    {
        public NthPrime()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is bool ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}