using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Transpose : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "String";
            testMethod.Input["lines"] = new MultiLineString(testMethod.Input["lines"]);
            testMethod.Expected = new MultiLineString(testMethod.Expected);

            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
        }
    }
}