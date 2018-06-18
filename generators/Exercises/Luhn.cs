using Generators.Input;

namespace Generators.Exercises
{
    public class Luhn : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Property = "IsValid";
        }
    }
}
