using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class ResistorColorTrio : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Expected = ConvertExpected(testMethod.Expected);
        }

        private static string ConvertExpected(dynamic expected) => $"{expected["value"]} {expected["unit"]}";
    }
}
