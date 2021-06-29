using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Poker : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariableForTested = true;
        }
    }
}
