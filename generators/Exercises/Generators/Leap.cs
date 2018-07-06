using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Leap : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "IsLeapYear";
        }
    }
}