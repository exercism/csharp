using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SpaceAge : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = $"On{data.Input["planet"]}";
            data.SetInputParameters();
            data.SetConstructorInputParameters("seconds");
        }
    }
}