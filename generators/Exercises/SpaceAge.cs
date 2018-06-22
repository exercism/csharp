using Generators.Output;

namespace Generators.Exercises
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