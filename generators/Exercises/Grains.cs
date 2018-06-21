using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class Grains : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (ShouldThrowException(data.Expected))
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            else
                data.Expected = (ulong)data.Expected;
        }

        private static bool ShouldThrowException(dynamic value) => value is int i && i == -1;
    }
}