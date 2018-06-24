using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Triangle : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Property == "equilateral")
                data.TestedMethod = "IsEquilateral";
            else if (data.Property == "isosceles")
                data.TestedMethod = "IsIsosceles";
            else if (data.Property == "scalene")
                data.TestedMethod = "IsScalene";

            data.Input["x"] = data.Input["sides"][0];
            data.Input["y"] = data.Input["sides"][1];
            data.Input["z"] = data.Input["sides"][2];
            data.Input.Remove("sides");
            data.SetInputParameters("x", "y", "z");

            data.UseFullDescriptionPath = true;
        }
    }
}