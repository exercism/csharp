using Generators.Input;

namespace Generators.Exercises
{
    public class RailFenceCipher : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.SetConstructorInputParameters("rails");
        }
    }
}