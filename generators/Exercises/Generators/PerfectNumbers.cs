using System;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
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