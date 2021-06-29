using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class PrimeFactors : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Input["value"] = (long)testMethod.Input["value"];

            if (testMethod.Expected is int[] expected)
            {
                testMethod.Expected = expected.Select(l => (long)l).ToArray();
            }
        }
    }
}