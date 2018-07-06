using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Matrix : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "string" };
            testMethod.InputParameters = new[] { "index" };
        }
    }
}
