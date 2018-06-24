using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Sieve : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.ExceptionThrown = data.Input["limit"] < 2 ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}