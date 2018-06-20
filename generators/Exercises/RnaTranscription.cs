using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class RnaTranscription : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.ExceptionThrown = data.Expected is null ? typeof(ArgumentException) : null;
        }
    }
}