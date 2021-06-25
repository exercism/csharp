using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CryptoSquare : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
        }
    }
}