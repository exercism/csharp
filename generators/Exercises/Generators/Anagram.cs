using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Anagram : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.ConstructorInputParameters = new[] { "subject" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
        }
    }
}