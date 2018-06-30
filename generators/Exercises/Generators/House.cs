using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class House : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.Expected = new MultiLineString(data.Expected);

            if (data.Input["startVerse"] == data.Input["endVerse"])
            {
                data.SetInputParameters("startVerse");
            }
        }
    }
}