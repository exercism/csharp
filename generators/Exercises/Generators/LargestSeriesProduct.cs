using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class LargestSeriesProduct : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "GetLargestProduct";

            if (testMethod.Expected == -1)
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}