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
                canonicalDataCase.Input = string.Join("\n", (JArray)canonicalDataCase.Input);
                canonicalDataCase.Expected = string.Join("\n", (JArray)canonicalDataCase.Expected);
                canonicalDataCase.UseInputParameters = true;
                canonicalDataCase.UseExpectedParameter = true;
            }
        }
    }
}