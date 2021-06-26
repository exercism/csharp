using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class PhoneNumber : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;

            if (!(testMethod.Expected is string))
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}