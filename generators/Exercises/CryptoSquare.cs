using Generators.Input;

namespace Generators.Exercises
{
    public class CryptoSquare : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
        }
    }
}