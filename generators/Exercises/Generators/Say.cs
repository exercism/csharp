using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Say : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "InEnglish";
            testMethod.Input["number"] = (long)testMethod.Input["number"]; 

            if (testMethod.ExpectedIsError)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}