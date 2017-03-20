using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class RaindropsExercise : EqualityExercise
    {
        public RaindropsExercise() : base("raindrops")
        {
        }

        protected override TestMethodOptions CreateTestMethodOptions(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodOptions = base.CreateTestMethodOptions(canonicalData, canonicalDataCase, index);
            testMethodOptions.InputProperty = "number";

            return testMethodOptions;
        }
    }
}