using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class PhoneNumber : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is null ? typeof(ArgumentException) : null;
            }
        }
    }
}