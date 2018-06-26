using Exercism.CSharp.Output;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Triangle : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = $"Is{data.Property.Humanize()}";

            data.Input["x"] = data.Input["sides"][0];
            data.Input["y"] = data.Input["sides"][1];
            data.Input["z"] = data.Input["sides"][2];
            data.Input.Remove("sides");
            data.SetInputParameters("x", "y", "z");

            data.UseFullDescriptionPath = true;
        }
    }
}