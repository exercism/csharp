using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Say : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Property = "InEnglish";
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is int ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}