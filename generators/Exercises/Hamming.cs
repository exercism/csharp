using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class Hamming : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is int ? null : typeof(ArgumentException);
        }
    }
}
