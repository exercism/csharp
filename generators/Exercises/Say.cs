using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Say : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "InEnglish";
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is long ? typeof(ArgumentOutOfRangeException) : null;
            }
        }
    }
}