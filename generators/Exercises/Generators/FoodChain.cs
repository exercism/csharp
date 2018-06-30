using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class FoodChain : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Expected = new MultiLineString(data.Expected);
            data.UseVariableForExpected = true;

            if (data.Input["startVerse"] == data.Input["endVerse"])
            {
                data.SetInputParameters("startVerse");
            }
        }
    }
}