using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Hamming : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is int ? null : typeof(ArgumentException);
        }
    }
}
