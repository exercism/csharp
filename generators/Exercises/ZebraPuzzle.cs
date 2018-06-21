using Generators.Output;
using Humanizer;

namespace Generators.Exercises
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