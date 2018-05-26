using Generators.Input;

namespace Generators.Exercises
{
    public class FoodChain : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
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
}