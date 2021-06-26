using System;

using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Change : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;

            if (testMethod.ExpectedIsError)
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}