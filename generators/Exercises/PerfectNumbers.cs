using System;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class PerfectNumbers : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (canonicalDataCase.Expected is string classificationType)
                    canonicalDataCase.Expected = new UnescapedValue($"Classification.{classificationType.Transform(To.SentenceCase)}");
                else
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            }
        }
    }
}