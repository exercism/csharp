using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RnaTranscription : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected is null)
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}