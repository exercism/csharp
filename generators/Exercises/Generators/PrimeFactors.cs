using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PrimeFactors : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod) =>
            testMethod.Input["value"] = (long)testMethod.Input["value"];
    }
}