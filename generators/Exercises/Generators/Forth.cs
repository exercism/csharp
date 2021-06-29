using Exercism.CSharp.Output;
using System;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Forth : ExerciseGenerator
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
