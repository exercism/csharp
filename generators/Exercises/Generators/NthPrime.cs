using System;

using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class NthPrime : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.ExpectedIsError)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}