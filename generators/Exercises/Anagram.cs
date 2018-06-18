using Generators.Input;

namespace Generators.Exercises
{
    public class Anagram : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.SetConstructorInputParameters("subject");
        }
    }
}