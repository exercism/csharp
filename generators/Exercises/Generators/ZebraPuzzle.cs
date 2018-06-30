using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
{
    public class ZebraPuzzle : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            var nationality = data.Expected as string;
            data.Expected = new UnescapedValue($"Nationality.{nationality.Humanize()}");
        }
    }
}