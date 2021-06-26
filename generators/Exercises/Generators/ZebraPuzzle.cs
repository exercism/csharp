using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class ZebraPuzzle : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Expected = Render.Enum("Nationality", testMethod.Expected);
        }
    }
}