using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Leap : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "IsLeapYear";
        }
    }
}