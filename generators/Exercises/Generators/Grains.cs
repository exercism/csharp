using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Grains : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected is Dictionary<String, object>)
                testMethod.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            else
                testMethod.Expected = (ulong)testMethod.Expected;
        }
    }
}