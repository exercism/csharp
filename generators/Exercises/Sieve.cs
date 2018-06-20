using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class Sieve : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariableForExpected = true;
            data.ExceptionThrown = data.Input["limit"] < 2 ? typeof(ArgumentOutOfRangeException) : null;
        }
    }
}