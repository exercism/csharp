using Generators.Input;

namespace Generators.Exercises
{
    public class ScaleGenerator : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariableForExpected = true;
        }
    }
}