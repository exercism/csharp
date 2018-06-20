using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class FoodChain : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
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