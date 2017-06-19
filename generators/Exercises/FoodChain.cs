using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class FoodChain : EqualityExercise
    {
        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.Options.ExpectedFormat = ExpectedFormat.FormattedAsMultilineString;

            return testMethodData;
        }
    }
}