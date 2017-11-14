using Generators.Input;

namespace Generators.Exercises
{
    public class Transpose : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "String";
                canonicalDataCase.Properties["input"] = ConvertHelper.ToMultiLineString(canonicalDataCase.Properties["input"]);
                canonicalDataCase.Expected = ConvertHelper.ToMultiLineString(canonicalDataCase.Expected);

                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }
    }
}