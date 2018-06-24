using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwelveDays : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.Expected = ConvertHelper.ToMultiLineString(data.Expected);

            if (data.Input["startVerse"] == data.Input["endVerse"])
            {
                data.SetInputParameters("startVerse");
            }
        }
    }
}
