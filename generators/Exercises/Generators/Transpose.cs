using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Transpose : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "String";
            data.Input["lines"] = new MultiLineString(data.Input["lines"]);
            data.Expected = new MultiLineString(data.Expected);

            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }
    }
}