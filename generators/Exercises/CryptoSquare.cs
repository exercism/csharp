using Generators.Input;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class CryptoSquare : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;

                if (canonicalDataCase.Expected is JArray expected)
                    canonicalDataCase.Expected = expected.Values<string>();
            }
        }
    }
}