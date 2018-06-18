using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class NthPrime : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is Dictionary<string, object> ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}