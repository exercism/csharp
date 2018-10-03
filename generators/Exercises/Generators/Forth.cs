using Exercism.CSharp.Output;
using System;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Forth : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            if (testMethod.Expected == null || string.Join(" ", testMethod.Expected).StartsWith("[error"))
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
