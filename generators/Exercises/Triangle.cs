using Generators.Input;

namespace Generators.Exercises
{
    public class Triangle : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            if (canonicalDataCase.Property == "equilateral")
                canonicalDataCase.Property = "IsEquilateral";
            else if (canonicalDataCase.Property == "isosceles")
                canonicalDataCase.Property = "IsIsosceles";
            else if (canonicalDataCase.Property == "scalene")
                canonicalDataCase.Property = "IsScalene";

            canonicalDataCase.Input["x"] = canonicalDataCase.Input["sides"][0];
            canonicalDataCase.Input["y"] = canonicalDataCase.Input["sides"][1];
            canonicalDataCase.Input["z"] = canonicalDataCase.Input["sides"][2];
            canonicalDataCase.Input.Remove("sides");
            canonicalDataCase.SetInputParameters("x", "y", "z");

            canonicalDataCase.UseFullDescriptionPath = true;
        }
    }
}