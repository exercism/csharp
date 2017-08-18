using Generators.Input;
using System;

namespace Generators.Exercises
{
    public class CollatzConjecture : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonical)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.ExceptionThrown = (long)canonicalDataCase.Input["number"] <= 0 ? typeof(ArgumentException) : null;
            }
        }
    }
}