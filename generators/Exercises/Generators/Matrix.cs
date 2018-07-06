using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Matrix : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.SetConstructorInputParameters("string");
            testMethod.SetInputParameters("index");
        }
    }
}
