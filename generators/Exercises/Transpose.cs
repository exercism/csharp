using Generators.Input;

namespace Generators.Exercises
{
    public class Transpose : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Property = "String";
            canonicalDataCase.Input["lines"] = ConvertHelper.ToMultiLineString(canonicalDataCase.Input["lines"], "");
            canonicalDataCase.Expected = ConvertHelper.ToMultiLineString(canonicalDataCase.Expected, "");

            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
        }
    }
}