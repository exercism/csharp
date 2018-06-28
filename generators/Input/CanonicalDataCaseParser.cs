using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Input
{
    public static class CanonicalDataCaseParser
    {
        public static IReadOnlyCollection<CanonicalDataCase> Parse(JToken canonicalDataCaseJToken) 
            => GetCanonicalDataCaseTokens(canonicalDataCaseJToken)
                .Select(ParseWithIndex)
                .ToArray();

        private static IEnumerable<JToken> GetCanonicalDataCaseTokens(JToken currentJToken)
        {
            switch (currentJToken)
            {
                case JArray jArray:
                    return jArray.SelectMany(GetCanonicalDataCaseTokens);
                case JObject jObject when jObject.TryGetValue("cases", out var casesJToken) && casesJToken is JArray childJArray:
                    return childJArray.SelectMany(GetCanonicalDataCaseTokens);
                case JObject jObject when jObject.ContainsKey("property"):
                    return new[] { jObject };
                default:
                    return Enumerable.Empty<JToken>();
            }
        }

        private static CanonicalDataCase ParseWithIndex(JToken canonicalDataCaseJToken, int index)
            => new CanonicalDataCase(
                index: index,
                property: canonicalDataCaseJToken.Value<string>("property"),
                input: JTokenHelper.ConvertJToken(canonicalDataCaseJToken["input"]),
                expected: JTokenHelper.ConvertJToken(canonicalDataCaseJToken["expected"]),
                description: canonicalDataCaseJToken.Value<string>("description"),
                descriptionPath: GetDescriptionPath(canonicalDataCaseJToken));

        private static string[] GetDescriptionPath(JToken canonicalDataCaseJToken) 
            => canonicalDataCaseJToken.ParentsAndSelf()
                .Where(token => token.Type == JTokenType.Object)
                .Select(token => token.Value<string>("description"))
                .Where(description => description != null)
                .Reverse()
                .ToArray();
    }
}
