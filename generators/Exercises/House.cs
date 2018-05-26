using Generators.Input;

namespace Generators.Exercises
{
    public class House : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Expected = ConvertHelper.ToMultiLineString(canonicalDataCase.Expected);

                if (canonicalDataCase.Input["startVerse"] == canonicalDataCase.Input["endVerse"])
                {
                    canonicalDataCase.SetInputParameters("startVerse");
                }
            }
        }
    }
}