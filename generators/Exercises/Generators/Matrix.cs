using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Matrix : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "string" };
        }
    }
}
