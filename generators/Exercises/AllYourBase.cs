using System;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class AllYourBase : Exercise
    {
        public AllYourBase()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                dynamic input = canonicalDataCase.Input;
                input["input_digits"] = ((JArray)input["input_digits"]).Values<int>();
                canonicalDataCase.Input = input;

                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is null ? typeof(ArgumentException) : null;
                canonicalDataCase.UseInputParameters = true;
                canonicalDataCase.UseExpectedParameter = canonicalDataCase.ExceptionThrown == null;
            }
        }
    }
}