using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Wordy : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected is bool)
                data.ExceptionThrown = typeof(ArgumentException);
        }
    }
}