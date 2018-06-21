using Generators.Output;

namespace Generators.Exercises
{
    public class RailFenceCipher : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.SetConstructorInputParameters("rails");
        }
    }
}