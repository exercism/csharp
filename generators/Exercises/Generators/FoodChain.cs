using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class FoodChain : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Expected = new MultiLineString(testMethod.Expected);
            testMethod.UseVariableForExpected = true;

            if (testMethod.Input["startVerse"] == testMethod.Input["endVerse"])
            {
                testMethod.SetInputParameters("startVerse");
            }
        }
    }
}