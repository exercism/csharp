using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class RomanNumerals : EqualityExercise
    {
        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.CanonicalDataCase.Property = "ToRoman";
            testMethodData.CanonicalDataCase.Description = "Number_" + testMethodData.CanonicalDataCase.Description;

            return testMethodData;
        }

        protected override TestMethodOptions CreateTestMethodOptions(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index) 
        {
            var testMethodOptions = new TestMethodOptions();
            testMethodOptions.TestedMethodType = TestedMethodType.Extension;

            return testMethodOptions;
        }
    }
}