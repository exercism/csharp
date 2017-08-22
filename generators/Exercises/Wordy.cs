using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Wordy : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is bool ? typeof(ArgumentException) : null;
        }
    }
}