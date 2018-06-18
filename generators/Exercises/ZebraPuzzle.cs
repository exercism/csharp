using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class ZebraPuzzle : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {   
            var nationality = canonicalDataCase.Expected as string;
            canonicalDataCase.Expected = new UnescapedValue($"Nationality.{nationality.Humanize()}");
        }
    }
}