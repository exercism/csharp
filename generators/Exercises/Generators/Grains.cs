using System;

using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Grains : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.ExpectedIsError)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            else
                testMethod.Expected = (ulong)testMethod.Expected;
        }
    }
}