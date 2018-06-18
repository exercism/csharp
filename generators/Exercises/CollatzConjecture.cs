using Generators.Input;
using System;

namespace Generators.Exercises
{
    public class CollatzConjecture : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Input["number"] <= 0 ? typeof(ArgumentException) : null;
        }
    }
}