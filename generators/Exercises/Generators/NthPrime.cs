using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class NthPrime : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is Dictionary<string, object> ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}