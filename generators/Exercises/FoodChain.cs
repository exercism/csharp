using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class FoodChain : Exercise
    {
        public FoodChain()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
                canonicalDataCase.Expected = new MultiLineString((JArray)canonicalDataCase.Expected);
        }
    }
}