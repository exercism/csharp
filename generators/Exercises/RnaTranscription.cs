using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class RnaTranscription : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is null ? typeof(ArgumentException) : null;
        }
    }
}