using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class LargestSeriesProduct : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "GetLargestProduct";

            var caseInputLessThanZero = (long)data.Expected == -1;
            data.ExceptionThrown = caseInputLessThanZero ? typeof(ArgumentException) : null;
        }
    }
}