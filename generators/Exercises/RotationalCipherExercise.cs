using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class RotationalCipherExercise : EqualityExercise
    {
        public RotationalCipherExercise() : base("rotational-cipher")
        {
        }

        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);
            testMethodData.CanonicalDataCase.Input = new[]
            {
                testMethodData.CanonicalDataCase.Data["text"],
                testMethodData.CanonicalDataCase.Data["shiftKey"]
            };
            return testMethodData;
        }
    }
}