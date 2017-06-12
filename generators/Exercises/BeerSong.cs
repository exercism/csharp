using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class BeerSong : EqualityExercise
    {
        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.Options.ExpectedFormat = ExpectedFormat.FormattedAsMultilineString;

            return testMethodData;
        }
    }
}