using Generators.Output;

namespace Generators.Exercises
{
    public class Poker : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.UseVariableForTested = true;
        }
    }
}
