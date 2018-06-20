using System;
using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class NthPrime : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.ExceptionThrown = data.Expected is Dictionary<string, object> ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}