using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
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