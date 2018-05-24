using System;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class ZebraPuzzle : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                var nationality = canonicalDataCase.Expected as string;
                canonicalDataCase.Expected = new UnescapedValue($"Nationality.{nationality.Humanize()}");
            }
        }
    }
}