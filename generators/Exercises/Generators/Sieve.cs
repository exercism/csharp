using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Sieve : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;

            if (testMethod.Input["limit"] < 2)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}