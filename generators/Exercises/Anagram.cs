using Generators.Input;

namespace Generators.Exercises
{
    public class Anagram : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.SetConstructorInputParameters("subject");
            }
        }
    }
}