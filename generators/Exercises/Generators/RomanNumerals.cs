using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class RomanNumerals : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.ExtensionMethod;
            testMethod.TestedMethod = "ToRoman";
        }
    }
}