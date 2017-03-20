using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class AcronymExercise : EqualityExercise
    {
        public AcronymExercise() : base("acronym")
        {
        }

        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.Options.InputProperty = "phrase";

            return testMethodData;
        }
    }
}