using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public static class CanonicalDataCasesJson
    {
        private const string TokensPath = "$..*[?(@.property)]";

        public static CanonicalDataCase[] ToArray(JToken casesToken)
        {
            var caseTokens = casesToken.SelectTokens(TokensPath);
            var canonicalDataCases = caseTokens.Select(x => x.ToObject<CanonicalDataCase>()).ToArray();

            ConvertEmptyJArrayToArray(canonicalDataCases);

            return canonicalDataCases;
        }

        private static void ConvertEmptyJArrayToArray(CanonicalDataCase[] canonicalDataCases)
        {
            foreach (var groupedCanonicalDataCases in canonicalDataCases.ToLookup(c => c.Property))
            {
                foreach (var groupedProperties in groupedCanonicalDataCases.SelectMany(x => x.Properties).ToLookup(x => x.Key))
                {
                    var arrayType = GetArrayType(groupedProperties);
                    if (arrayType == null)
                        continue;

                    foreach (var groupedCanonicalDataCase in GetEmptyJArrays(groupedCanonicalDataCases, groupedProperties))
                        groupedCanonicalDataCase.Properties[groupedProperties.Key] = Array.CreateInstance(arrayType, 0);
                }
            }
        }

        private static Type GetArrayType(IGrouping<string, KeyValuePair<string, dynamic>> groupedProperties)
        {
            if (groupedProperties.Any(x => x.Value is string[]))
                return typeof(string);

            if (groupedProperties.Any(x => x.Value is int[]))
                return typeof(int);

            if (groupedProperties.Any(x => x.Value is float[]))
                return typeof(float);

            return null;
        }

        private static IEnumerable<CanonicalDataCase> GetEmptyJArrays(IGrouping<string, CanonicalDataCase> groupedCanonicalDataCases, IGrouping<string, KeyValuePair<string, dynamic>> groupedProperties)
            => groupedCanonicalDataCases.Where(canonicalDataCase => canonicalDataCase.Properties.ContainsKey(groupedProperties.Key) && IsEmptyJArray(canonicalDataCase, groupedProperties));

        private static bool IsEmptyJArray(CanonicalDataCase x, IGrouping<string, KeyValuePair<string, dynamic>> groupedProperties)
            => x.Properties[groupedProperties.Key] is JArray jArray && jArray.Count == 0;
    }
}