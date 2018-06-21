using Generators.Output;

namespace Generators.Exercises
{
    public class Triangle : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Property == "equilateral")
                data.Property = "IsEquilateral";
            else if (data.Property == "isosceles")
                data.Property = "IsIsosceles";
            else if (data.Property == "scalene")
                data.Property = "IsScalene";

            data.Input["x"] = data.Input["sides"][0];
            data.Input["y"] = data.Input["sides"][1];
            data.Input["z"] = data.Input["sides"][2];
            data.Input.Remove("sides");
            data.SetInputParameters("x", "y", "z");

            data.UseFullDescriptionPath = true;
        }
    }
}