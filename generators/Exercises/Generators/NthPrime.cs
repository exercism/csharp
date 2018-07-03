using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class NthPrime : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected is Dictionary<string, object>)
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}