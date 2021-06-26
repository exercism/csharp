using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Series : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;

            if (!(testMethod.Expected is string[]))
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}