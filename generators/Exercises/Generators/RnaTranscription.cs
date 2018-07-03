using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RnaTranscription : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected is null)
                data.ExceptionThrown = typeof(ArgumentException);
        }
    }
}