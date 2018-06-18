using Generators.Input;

namespace Generators.Exercises
{
    public class SpaceAge : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Property = $"On_{canonicalDataCase.Input["planet"]}";
            canonicalDataCase.SetInputParameters();
            canonicalDataCase.SetConstructorInputParameters("seconds");
        }
    }
}