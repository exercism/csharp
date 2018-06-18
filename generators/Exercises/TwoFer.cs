using Generators.Input;

namespace Generators.Exercises
{
    public class TwoFer : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {   
            canonicalDataCase.Property = "Name";
        }
    }
}