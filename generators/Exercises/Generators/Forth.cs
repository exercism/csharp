using Exercism.CSharp.Output;
using System;
using System.Collections.Generic;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Forth : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            if (testMethod.ExpectedIsError)
            {
                testMethod.ExceptionThrown = typeof(InvalidOperationException);
            }
            else
            {
                testMethod.Expected = string.Join(" ", testMethod.Expected);
            }
        }
    }
}
