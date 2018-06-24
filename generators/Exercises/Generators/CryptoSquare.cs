using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CryptoSquare : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }
    }
}