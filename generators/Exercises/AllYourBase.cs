using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class AllYourBase : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                //canonicalDataCase.Input["input_digits"] = canonicalDataCase.Input["input_digits"].ConvertToEnumerable<int>();

                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is null ? typeof(ArgumentException) : null;
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}