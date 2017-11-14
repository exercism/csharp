using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Grains : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (ShouldThrowException(canonicalDataCase.Expected))
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentOutOfRangeException);
                else
                    canonicalDataCase.Expected = (ulong)canonicalDataCase.Expected;
            }
        }

        private static bool ShouldThrowException(dynamic value) => value == -1;
    }
}