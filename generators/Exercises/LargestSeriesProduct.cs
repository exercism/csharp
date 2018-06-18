using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class LargestSeriesProduct : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Property = "GetLargestProduct";
                
            var caseInputLessThanZero = (long)canonicalDataCase.Expected == -1;
            canonicalDataCase.ExceptionThrown = caseInputLessThanZero ? typeof(ArgumentException) : null;
        }
    }
}