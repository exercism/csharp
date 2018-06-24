using Generators.Helpers;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
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