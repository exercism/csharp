using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Sieve : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Input["limit"] < 2 ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}