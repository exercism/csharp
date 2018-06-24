using Generators.Helpers;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class BeerSong : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.Expected = ConvertHelper.ToMultiLineString(data.Expected);
        }
    }
}