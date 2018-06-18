using Generators.Input;

namespace Generators.Exercises
{
    public class BeerSong : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.Expected = ConvertHelper.ToMultiLineString(canonicalDataCase.Expected);
        }
    }
}