using System;
using Generators.Output;

namespace Generators.Exercises
{
    public class CollatzConjecture : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.ExceptionThrown = data.Input["number"] <= 0 ? typeof(ArgumentException) : null;
        }
    }
}