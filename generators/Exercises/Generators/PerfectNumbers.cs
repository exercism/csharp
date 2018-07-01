using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PerfectNumbers : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected is string)
                data.Expected = Render.Enum("Classification", data.Expected);
            else
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}