using Generators.Output;

namespace Generators.Exercises
{
    public class BracketPush : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["value"] = data.Input["value"].Replace("\\", "\\\\");
            data.UseVariablesForInput = true;
        }
    }
}