using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwoFer : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "Name";
            
            if (testMethod.Input["name"] is null)
                testMethod.SetInputParameters();
        }
    }
}