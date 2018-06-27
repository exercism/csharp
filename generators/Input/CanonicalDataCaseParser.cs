using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Input
{
    public static class CanonicalDataCaseParser
    {
        private const string TokensPath = "$..*[?(@.property)]";

        public static IReadOnlyCollection<CanonicalDataCase> Parse(JArray canonicalDataCasesJArray)
            => canonicalDataCasesJArray
                .SelectTokens(TokensPath)
                .Select(Parse)
                .ToArray();

        private static CanonicalDataCase Parse(JToken canonicalDataCaseJToken, int index)
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
