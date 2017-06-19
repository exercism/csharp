using System;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class PerfectNumbers : Exercise
    {
        public PerfectNumbers()
        {
            Configuration.ExceptionType = typeof(ArgumentOutOfRangeException);
            Configuration.ExpectedFormat = ExpectedFormat.Unformatted;

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                if (canonicalDataCase.Expected is string classificationType)
                    canonicalDataCase.Expected = $"Classification.{classificationType.Transform(To.TitleCase)}";
            }
        }
    }
}