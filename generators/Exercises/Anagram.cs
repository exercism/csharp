using Generators.Output;

namespace Generators.Exercises
{
    public class Anagram : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.SetConstructorInputParameters("subject");
        }
    }
}