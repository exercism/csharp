using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class AtbashCipherExercise : EqualityExercise
    {
        public AtbashCipherExercise() : base("atbash-cipher")
        {
        }

        protected override TestMethodOptions CreateTestMethodOptions(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodOptions = base.CreateTestMethodOptions(canonicalData, canonicalDataCase, index);
            testMethodOptions.InputProperty = "phrase";

            return testMethodOptions;
        }
    }
}