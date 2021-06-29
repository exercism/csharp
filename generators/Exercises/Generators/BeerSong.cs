using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class BeerSong : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
            testMethod.Expected = new MultiLineString(testMethod.Expected);
        }
    }
}