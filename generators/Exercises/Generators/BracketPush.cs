using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class BracketPush : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Input["value"] = testMethod.Input["value"].Replace("\\", "\\\\");
            testMethod.UseVariablesForInput = true;
        }
    }
}