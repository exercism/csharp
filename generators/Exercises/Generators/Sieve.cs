using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Sieve : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;

            if (data.Input["limit"] < 2)
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}