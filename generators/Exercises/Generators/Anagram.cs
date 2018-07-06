using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Anagram : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.SetConstructorInputParameters("subject");
        }
    }
}