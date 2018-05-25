using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Change : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;

                if (canonicalDataCase.Expected is int)
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
            }
        }
    }
}