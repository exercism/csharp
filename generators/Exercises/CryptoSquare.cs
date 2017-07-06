using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class CryptoSquare : Exercise
    {
        public CryptoSquare()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;

                if (canonicalDataCase.Expected is JArray expected)
                    canonicalDataCase.Expected = expected.Values<string>();
            }
        }
    }
}