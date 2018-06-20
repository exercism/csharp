using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class BeerSong : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariableForExpected = true;
            data.Expected = ConvertHelper.ToMultiLineString(data.Expected);
        }
    }
}