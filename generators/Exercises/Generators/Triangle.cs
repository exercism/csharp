using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Triangle : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = $"Is{testMethod.TestedMethod}".ToTestedMethodName();

            testMethod.Input["x"] = testMethod.Input["sides"][0];
            testMethod.Input["y"] = testMethod.Input["sides"][1];
            testMethod.Input["z"] = testMethod.Input["sides"][2];
            testMethod.Input.Remove("sides");
            testMethod.SetInputParameters("x", "y", "z");

            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;
        }
    }
}