using System;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class PerfectNumbers : Exercise
    {
        public PerfectNumbers()
        {
            Options.ExceptionType = typeof(ArgumentOutOfRangeException);
            Options.ExpectedFormat = ExpectedFormat.Unformatted;

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                if (canonicalDataCase.Expected is string classificationType)
                    canonicalDataCase.Expected = GetClassification(classificationType);
            }
        }

        private static string GetClassification(string classificationType) => $"Classification.{classificationType.Transform(To.TitleCase)}";
    }
}