using Generators.Input;

namespace Generators.Exercises
{
    public class FoodChain : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Expected = ConvertHelper.ToMultiLineString(canonicalDataCase.Expected);
            canonicalDataCase.UseVariableForExpected = true;

            if (canonicalDataCase.Input["startVerse"] == canonicalDataCase.Input["endVerse"])
            {
                canonicalDataCase.SetInputParameters("startVerse");
            }
        }
    }
}