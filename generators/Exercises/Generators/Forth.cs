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
                testMethod.ExceptionThrown = testMethod.Expected!["error"] == "divide by zero" ? typeof(DivideByZeroException) : typeof(InvalidOperationException);
            }
            else
            {
                testMethod.Expected = string.Join(" ", testMethod.Expected);
            }
        }
    }
}
