using Generators.Input;

namespace Generators.Exercises
{
    public class SpaceAge : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = $"On_{canonicalDataCase.Input["planet"]}";
                canonicalDataCase.SetInputParameters();
                canonicalDataCase.SetConstructorInputParameters("seconds");
            }
        }
    }
}