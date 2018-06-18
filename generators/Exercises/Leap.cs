using Generators.Input;

namespace Generators.Exercises
{
    public class Leap : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Property = "IsLeapYear";
        }
    }
}