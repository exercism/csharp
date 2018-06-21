using Generators.Output;

namespace Generators.Exercises
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