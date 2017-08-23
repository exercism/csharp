using Generators.Input;
using System;

namespace Generators.Exercises
{
    public class CollatzConjecture : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ExceptionThrown = (long)canonicalDataCase.Input["number"] <= 0 ? typeof(ArgumentException) : null;
            }
        }
    }
}