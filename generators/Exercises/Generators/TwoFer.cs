using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class TwoFer : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "Speak";
            
            if (testMethod.Input["name"] is null)
                testMethod.InputParameters = Array.Empty<string>();
        }
    }
}