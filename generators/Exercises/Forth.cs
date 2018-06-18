using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Forth : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseFullDescriptionPath = true;

            if (canonicalDataCase.Expected == null)
            {
                canonicalDataCase.ExceptionThrown = typeof(InvalidOperationException);
            }
            else
            {
                canonicalDataCase.Expected = string.Join(" ", canonicalDataCase.Expected);
            }
        }
    }
}
