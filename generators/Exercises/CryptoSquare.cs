using Generators.Output;

namespace Generators.Exercises
{
    public class CryptoSquare : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }
    }
}