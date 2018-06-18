using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public class CanonicalDataParser
    {
        private readonly CanonicalDataFile _canonicalDataFile;

        public CanonicalDataParser(CanonicalDataFile canonicalDataFile) => _canonicalDataFile = canonicalDataFile;

        public CanonicalData Parse(string exercise)
        {
            var canonicalDataJsonContents = _canonicalDataFile.Contents(exercise);
            var canonicalDataJson = JObject.Parse(canonicalDataJsonContents);

            var name = ParseName(canonicalDataJson);
            var version = ParseVersion(canonicalDataJson);
            var canonicalDataCases = ParseCanonicalDataCases(canonicalDataJson);

            foreach (var canonicalDataCase in canonicalDataCases)
                canonicalDataCase.Exercise = name;

            return new CanonicalData(name, version, canonicalDataCases);
        }

        private static string ParseName(JToken canonicalDataJObject) => canonicalDataJObject.Value<string>("exercise");

        private static string ParseVersion(JToken canonicalDataJObject) => canonicalDataJObject.Value<string>("version");

        private static CanonicalDataCase[] ParseCanonicalDataCases(JObject canonicalDataJObject) => CanonicalDataCaseParser.Parse((JArray)canonicalDataJObject["cases"]);
    }
}