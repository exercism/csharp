using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Transpose : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "String";
            data.Input["lines"] = ConvertHelper.ToMultiLineString(data.Input["lines"], "");
            data.Expected = ConvertHelper.ToMultiLineString(data.Expected, "");

            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }
    }
}