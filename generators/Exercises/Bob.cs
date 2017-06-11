using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class BobExercise : EqualityExercise
    {
        public BobExercise() : base("bob")
        {
        }

        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.Options.InputProperty = "input";

            return testMethodData;
        }
    }
}