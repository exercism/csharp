using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Matrix : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.SetConstructorInputParameters("string");
            data.SetInputParameters("index");
        }
    }
}
