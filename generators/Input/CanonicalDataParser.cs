using System.Collections.Generic;
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

            var exerciseName = ParseExerciseName(canonicalDataJson);
            var version = ParseVersion(canonicalDataJson);
            var canonicalDataCases = ParseCanonicalDataCases(canonicalDataJson);

            return new CanonicalData(exerciseName, version, canonicalDataCases);
        }

        private static string ParseExerciseName(JToken canonicalDataJObject) => canonicalDataJObject.Value<string>("exercise");

        private static string ParseVersion(JToken canonicalDataJObject) => canonicalDataJObject.Value<string>("version");

        private static IReadOnlyCollection<CanonicalDataCase> ParseCanonicalDataCases(JObject canonicalDataJObject) 
            => CanonicalDataCaseParser.Parse((JArray)canonicalDataJObject["cases"]);
    }
}