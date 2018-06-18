using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Change : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;

            if (canonicalDataCase.Expected is int)
                canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
        }
    }
}