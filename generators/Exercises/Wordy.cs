using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class Wordy : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {   
            data.ExceptionThrown = data.Expected is bool ? typeof(ArgumentException) : null;
        }
    }
}