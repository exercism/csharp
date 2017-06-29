using System;

namespace Generators.Exercises
{
    public class Wordy : Exercise
    {
        public Wordy()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is bool ? typeof(ArgumentException) : null;
        }
    }
}