using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Transpose : Exercise
    {
        public Transpose()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Property = "String";
                canonicalDataCase.Input = new MultiLineString((JArray)canonicalDataCase.Input);
                canonicalDataCase.Expected = new MultiLineString((JArray)canonicalDataCase.Expected);
            }
        }
    }
}