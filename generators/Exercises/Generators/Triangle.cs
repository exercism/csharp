using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Triangle : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = $"Is{data.TestedMethod}".ToTestedMethodName();

            data.Input["x"] = data.Input["sides"][0];
            data.Input["y"] = data.Input["sides"][1];
            data.Input["z"] = data.Input["sides"][2];
            data.Input.Remove("sides");
            data.SetInputParameters("x", "y", "z");

            data.UseFullDescriptionPath = true;
        }
    }
}