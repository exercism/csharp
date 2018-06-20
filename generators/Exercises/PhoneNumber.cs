using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class PhoneNumber : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariablesForInput = true;
            data.ExceptionThrown = data.Expected is null ? typeof(ArgumentException) : null;
        }
    }
}