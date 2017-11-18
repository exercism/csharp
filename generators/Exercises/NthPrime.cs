using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class NthPrime : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is Dictionary<string, object> ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}