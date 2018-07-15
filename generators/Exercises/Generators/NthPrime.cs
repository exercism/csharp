using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class NthPrime : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected is Dictionary<string, object>)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}