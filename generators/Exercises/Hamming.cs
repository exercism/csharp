using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Hamming : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is int ? null : typeof(ArgumentException);
        }
    }
}
