using Generators.Output;

namespace Generators.Exercises
{
    public class SpaceAge : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.Property = $"On_{data.Input["planet"]}";
            data.SetInputParameters();
            data.SetConstructorInputParameters("seconds");
        }
    }
}