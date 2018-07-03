using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Hamming : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (!(data.Expected is int))
                data.ExceptionThrown = typeof(ArgumentException);
        }
    }
}
