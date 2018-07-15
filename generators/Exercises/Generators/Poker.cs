using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Poker : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariableForTested = true;
        }
    }
}
