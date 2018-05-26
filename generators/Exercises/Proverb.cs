using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Proverb : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Input["strings"] = ConvertHelper.ToArray<string>(canonicalDataCase.Input["strings"]);
                canonicalDataCase.Expected = ConvertHelper.ToArray<string>(canonicalDataCase.Expected);
            }
        }
    }
}