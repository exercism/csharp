using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Hamming : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is int ? null : typeof(ArgumentException);
        }
    }
}
