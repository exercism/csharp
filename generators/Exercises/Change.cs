using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class Change : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;

            if (data.Expected is int)
                data.ExceptionThrown = typeof(ArgumentException);
        }
    }
}