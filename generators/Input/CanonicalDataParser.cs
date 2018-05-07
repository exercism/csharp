using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public class CanonicalDataParser
    {
        private const string TokensPath = "$..*[?(@.property)]";

        private readonly CanonicalDataFile _canonicalDataFile;

        public CanonicalDataParser(CanonicalDataFile canonicalDataFile) => _canonicalDataFile = canonicalDataFile;

        public CanonicalData Parse(string exercise)
        {
            var canonicalDataJsonContents = _canonicalDataFile.Contents(exercise);
            var canonicalDataJson = JObject.Parse(canonicalDataJsonContents);

            var name = ParseName(canonicalDataJson);
            var version = ParseVersion(canonicalDataJson);
            var canonicalDataCases = ParseCanonicalDataCases(canonicalDataJson);

            return new CanonicalData(name, version, canonicalDataCases);
        }

        private static string ParseName(JObject canonicalDataJObject) => canonicalDataJObject.Value<string>("exercise");

        private static string ParseVersion(JObject canonicalDataJObject) => canonicalDataJObject.Value<string>("version");

        private static CanonicalDataCase[] ParseCanonicalDataCases(JObject canonicalDataJObject) => CanonicalDataCaseParser.Parse((JArray)canonicalDataJObject["cases"]);
    }
}