using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Series : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;

            if (!(testMethod.Expected is string[]))
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}