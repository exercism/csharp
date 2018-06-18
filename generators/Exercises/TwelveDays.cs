using Generators.Input;

namespace Generators.Exercises
{
    public class TwelveDays : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
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
