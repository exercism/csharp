using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class FoodChain : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Expected = ConvertHelper.ToMultiLineString(data.Expected);
            data.UseVariableForExpected = true;

            if (data.Input["startVerse"] == data.Input["endVerse"])
            {
                data.SetInputParameters("startVerse");
            }
        }
    }
}