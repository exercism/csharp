using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Triangle : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = $"Is{testMethod.TestedMethod}".ToTestedMethodName();
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            testMethod.Input["x"] = testMethod.Input["sides"][0];
            testMethod.Input["y"] = testMethod.Input["sides"][1];
            testMethod.Input["z"] = testMethod.Input["sides"][2];
            testMethod.Input.Remove("sides");
            testMethod.InputParameters = new[] { "x", "y", "z" };
        }
    }
}