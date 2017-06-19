using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class RomanNumerals : EqualityExercise
    {
        public RomanNumerals()
        {
            Options.TestedMethodType = TestedMethodType.Extension;
        }

        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.CanonicalDataCase.Property = "ToRoman";
            testMethodData.CanonicalDataCase.Description = "Number_" + testMethodData.CanonicalDataCase.Description;

            return testMethodData;
        }
    }
}