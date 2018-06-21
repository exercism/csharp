using System;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class PerfectNumbers : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected is string classificationType)
                data.Expected = new UnescapedValue($"Classification.{classificationType.Transform(To.SentenceCase)}");
            else
                data.ExceptionThrown = typeof(ArgumentOutOfRangeException);
        }
    }
}