using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RomanNumerals : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.ExtensionMethod;
            testMethod.TestedMethod = "ToRoman";
        }
    }
}