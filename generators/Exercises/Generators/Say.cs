using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Say : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "InEnglish";

            if (!(testMethod.Expected is string))
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}