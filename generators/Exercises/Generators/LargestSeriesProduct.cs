using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
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