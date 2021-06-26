using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class CollatzConjecture : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Input["number"] <= 0)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}
