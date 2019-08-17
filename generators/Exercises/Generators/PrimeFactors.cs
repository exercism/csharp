using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PrimeFactors : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected is int[])
            {
                testMethod.Expected = ((int[])testMethod.Expected).Select(l => (long)l).ToArray();
            }
        }
    }
}