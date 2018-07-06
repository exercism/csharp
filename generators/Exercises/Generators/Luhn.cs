using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Luhn : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "IsValid";
        }
    }
}
