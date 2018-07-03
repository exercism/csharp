using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PhoneNumber : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;

            if (data.Expected is null)
                data.ExceptionThrown = typeof(ArgumentException);
        }
    }
}