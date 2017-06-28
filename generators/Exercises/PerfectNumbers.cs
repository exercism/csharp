using System;
using Generators.Output;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class PerfectNumbers : Exercise
    {
        public PerfectNumbers()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is JObject ? typeof(ArgumentOutOfRangeException) : null;

                if (canonicalDataCase.Expected is string classificationType)
                    canonicalDataCase.Expected = new UnescapedValue($"Classification.{classificationType.Transform(To.SentenceCase)}");
            }
        }
    }
}