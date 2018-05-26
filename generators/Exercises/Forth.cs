using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Forth : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
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
}
