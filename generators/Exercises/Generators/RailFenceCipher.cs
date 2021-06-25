using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RailFenceCipher : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.ConstructorInputParameters = new[] { "rails" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
        }
    }
}