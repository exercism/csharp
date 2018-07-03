using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Grains : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected is int i && i == -1)
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            else
                data.Expected = (ulong)data.Expected;
        }
    }
}