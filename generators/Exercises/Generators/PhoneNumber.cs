using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PhoneNumber : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;

            if (testMethod.Expected is null)
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}