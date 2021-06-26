using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Input
{
    internal static class CanonicalDataCaseParser
    {
        public static IReadOnlyCollection<CanonicalDataCase> Parse(JToken canonicalDataCaseJToken) =>
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

        private static CanonicalDataCase ParseWithIndex(JToken canonicalDataCaseJToken, int index) =>
            new CanonicalDataCase(
                index,
                canonicalDataCaseJToken.Value<string>("property"),
                JTokenHelper.ConvertJToken(canonicalDataCaseJToken["input"]),
                JTokenHelper.ConvertJToken(canonicalDataCaseJToken["expected"]),
                canonicalDataCaseJToken.Value<string>("description"),
                GetDescriptionPath(canonicalDataCaseJToken));

        private static string[] GetDescriptionPath(JToken canonicalDataCaseJToken) =>
            canonicalDataCaseJToken.ParentsAndSelf()
                .Where(token => token.Type == JTokenType.Object)
                .Select(token => token.Value<string>("description"))
                .Where(description => description != null)
                .Reverse()
                .ToArray();
    }
}
