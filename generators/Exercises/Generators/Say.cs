using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Say : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "InEnglish";

            if (testMethod.Expected is int)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}