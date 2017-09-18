using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Sieve : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Input["limit"] < 2 ? typeof(ArgumentOutOfRangeException) : null;
            }
        }
    }
}