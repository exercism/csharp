using System;

namespace Generators.Exercises
{
    public class PerfectNumbers : Exercise
    {
        public PerfectNumbers()
        {
            Configuration.ExceptionType = typeof(ArgumentOutOfRangeException);

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                if (canonicalDataCase.Expected is string classificationType)
                    canonicalDataCase.Expected = Enum.Parse(typeof(Classification), classificationType, true);
            }
        }

        private enum Classification
        {
            Abundant,
            Deficient,
            Perfect,
        }
    }
}