using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class LargestSeriesProduct : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "GetLargestProduct";

            if (testMethod.Expected is System.Collections.IDictionary)
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}