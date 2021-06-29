using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Luhn : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod) => testMethod.TestedMethod = "IsValid";
    }
}
