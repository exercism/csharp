using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Input
{
    internal class CanonicalDataJsonParser
    {
        private readonly Options _options;

        private CanonicalDataJsonParser(Options options) => _options = options;

        public static CanonicalDataJsonParser Create(Options options)
        {
            var propSpecsRepository = new PropSpecsRepository(options);
            propSpecsRepository.SyncToLatest();

            return new CanonicalDataJsonParser(options);
        }

        public IReadOnlyCollection<TestCase> Parse(string exercise) =>
            Parse((JArray)ParseCanonicalData(exercise)["cases"]!);

        private JObject ParseCanonicalData(string exercise) =>
            JObject.Parse(File.ReadAllText(ExerciseCanonicalDataPath(exercise)));

        private string ExerciseCanonicalDataPath(string exercise) =>
            Path.Combine(_options.ProbSpecsDir, "exercises", exercise, "canonical-data.json");

        private static IReadOnlyCollection<TestCase> Parse(JToken canonicalDataCaseJToken) =>
            GetCanonicalDataCaseTokens(canonicalDataCaseJToken)
                .Select(ParseWithIndex)
                .ToArray();

        private static IEnumerable<JToken> GetCanonicalDataCaseTokens(JToken currentJToken) =>
            currentJToken switch
            {
                JArray jArray => jArray.SelectMany(GetCanonicalDataCaseTokens),
                JObject jObject when jObject.TryGetValue("cases", out var casesJToken) &&
                                     casesJToken is JArray childJArray => childJArray.SelectMany(
                    GetCanonicalDataCaseTokens),
                JObject jObject when jObject.ContainsKey("property") => new[] {jObject},
                _ => Enumerable.Empty<JToken>()
            };

        private static TestCase ParseWithIndex(JToken canonicalDataCaseJToken, int index) =>
            new TestCase(
                index,
                canonicalDataCaseJToken.Value<string>("uuid"),
                canonicalDataCaseJToken.Value<string>("property"),
                JTokenHelper.ConvertJToken(canonicalDataCaseJToken["input"]!),
                JTokenHelper.ConvertJToken(canonicalDataCaseJToken["expected"]!),
                canonicalDataCaseJToken.Value<string>("description"),
                GetDescriptionPath(canonicalDataCaseJToken),
                canonicalDataCaseJToken["scenarios"]?.ToObject<string[]>() ?? Array.Empty<string>());

        private static string[] GetDescriptionPath(JToken canonicalDataCaseJToken) =>
            canonicalDataCaseJToken.ParentsAndSelf()
                .Where(token => token.Type == JTokenType.Object)
                .Select(token => token.Value<string>("description"))
                .Where(description => !string.IsNullOrWhiteSpace(description))
                .Reverse()
                .ToArray()!;
    }
}