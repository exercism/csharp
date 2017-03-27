using Newtonsoft.Json.Linq;

namespace Generators.Data
{
    public static class CanonicalDataValue
    {
        public static string StringArrayToString(object expected)
            => string.Join("\\n\"+\n\"", ((JArray) expected).Values<string>());
    }
}
