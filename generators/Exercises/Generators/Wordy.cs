using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Wordy : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is bool ? typeof(ArgumentException) : null;
        }
    }
}