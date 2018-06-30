using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class ZebraPuzzle : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Expected = Render.Enum("Nationality", data.Expected);
        }
    }
}