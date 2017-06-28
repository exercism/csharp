using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class FoodChain : Exercise
    {
        public FoodChain()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Expected = string.Join("\n", (JArray)canonicalDataCase.Expected);
                canonicalDataCase.UseExpectedParameter = true;
            }
        }
    }
}