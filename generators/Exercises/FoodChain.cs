using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class FoodChain : EqualityExercise
    {
        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase);
            testMethodData.Options.ExpectedFormat = ExpectedFormat.FormattedAsMultilineString;

            return testMethodData;
        }
    }
}