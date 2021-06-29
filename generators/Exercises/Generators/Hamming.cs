using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Hamming : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (!(testMethod.Expected is int))
                testMethod.ExceptionThrown = typeof(ArgumentException);
        }
    }
}
