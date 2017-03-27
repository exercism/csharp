using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class FoodChainExercise : EqualityExercise
    {
        public FoodChainExercise() : base("food-chain")
        {
        }

        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);

            testMethodData.Options.UseVariableForExpected = true;
            testMethodData.CanonicalDataCase.Expected = CanonicalDataValue.StringArrayToString(canonicalDataCase.Expected);

            if (testMethodData.CanonicalDataCase.Data.ContainsKey("end verse"))
                testMethodData.CanonicalDataCase.Input = new[] { testMethodData.CanonicalDataCase.Data["start verse"], testMethodData.CanonicalDataCase.Data["end verse"] };
            else
                testMethodData.Options.InputProperty = "start verse";

            return testMethodData;
        }
    }
}