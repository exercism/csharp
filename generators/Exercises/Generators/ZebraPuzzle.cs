using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class ZebraPuzzle : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Expected = Render.Enum("Nationality", testMethod.Expected);
        }
    }
}