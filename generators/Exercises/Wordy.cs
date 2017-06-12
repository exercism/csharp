using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class Wordy : EqualityExercise
    {
        protected override TestMethodOptions CreateTestMethodOptions(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodOptions = base.CreateTestMethodOptions(canonicalData, canonicalDataCase, index);
            testMethodOptions.ThrowExceptionWhenExpectedValueEquals = x => x is bool;

            return testMethodOptions;
        }
    }
}