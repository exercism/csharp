using Generators.Input;

namespace Generators.Exercises
{
    public class Poker : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.UseVariableForTested = true;
        }
    }
}
