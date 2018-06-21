using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class RnaTranscription : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is null ? typeof(ArgumentException) : null;
        }
    }
}