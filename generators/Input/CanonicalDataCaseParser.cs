using System;
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
                properties: ToReadOnlyDictionary(canonicalDataCaseJToken),
                input: ToReadOnlyDictionary(canonicalDataCaseJToken["input"]),
                expected: ConvertJToken(canonicalDataCaseJToken["expected"]),
                description: canonicalDataCaseJToken.Value<string>("description"),
                descriptionPath: GetDescriptionPath(canonicalDataCaseJToken));

        private static string[] GetDescriptionPath(JToken canonicalDataCaseToken)
        {
            var descriptionPath = new Stack<string>();
            var currentToken = canonicalDataCaseToken;

            while (currentToken != null)
            {
                if (currentToken.Type == JTokenType.Object)
                {
                    var description = currentToken.SelectToken("description");
                    if (description == null)
                        break;

                    descriptionPath.Push(description.ToObject<string>());
                }

                currentToken = currentToken.Parent;
            }

            return descriptionPath.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        private static IReadOnlyDictionary<string, dynamic> ToReadOnlyDictionary(JToken jToken) => ConvertJToken(jToken);

        private static dynamic ConvertJToken(JToken jToken)
        {
            switch (jToken?.Type)
            {
                case JTokenType.Object:
                    return ConvertJObject((JObject)jToken);
                case JTokenType.Array:
                    return ConvertJArray((JArray)jToken);
                case JTokenType.Property:
                    return jToken.ToObject<IReadOnlyDictionary<string, dynamic>>();
                case JTokenType.Integer:
                    return ConvertIntegerJToken(jToken);
                case JTokenType.Float:
                    return jToken.ToObject<float>();
                case JTokenType.String:
                    return jToken.ToObject<string>();
                case JTokenType.Boolean:
                    return jToken.ToObject<bool>();
                case JTokenType.Date:
                    return jToken.ToObject<DateTime>();
                case JTokenType.Raw:
                    return jToken.ToObject<string>();
                case JTokenType.Bytes:
                    return jToken.ToObject<byte[]>();
                case JTokenType.Guid:
                    return jToken.ToObject<Guid>();
                case JTokenType.Uri:
                    return jToken.ToObject<Uri>();
                case JTokenType.TimeSpan:
                    return jToken.ToObject<TimeSpan>();
                default:
                    return null;
            }
        }

        private static dynamic ConvertJObject(JObject jObject)
        {
            var properties = jObject.ToObject<IDictionary<string, dynamic>>();

            for (var i = 0; i < properties.Count; i++)
            {
                var key = properties.Keys.ElementAt(i);
                var value = properties[key];
                properties[key] = value is JToken jToken ? ConvertJToken(jToken) : value;
            }

            return properties;
        }

        private static dynamic ConvertJArray(JArray jArray)
        {
            // We can't determine the type of the array if the array is empty
            if (!jArray.Any())
                return jArray;

            // We can only convert when all values have the same type
            if (jArray.Select(x => x.Type).Distinct().Count() != 1)
                return jArray;

            switch (jArray[0].Type)
            {
                case JTokenType.Object:
                    return jArray.Select(ConvertJToken).ToArray();
                case JTokenType.Integer:
                    var strings = jArray.ToObject<string[]>();
                    if (strings.All(str => int.TryParse(str, out _)))
                        return jArray.ToObject<int[]>();

                    if (strings.All(str => long.TryParse(str, out _)))
                        return jArray.ToObject<long[]>();

                    if (strings.All(str => ulong.TryParse(str, out _)))
                        return jArray.ToObject<ulong[]>();

                    return strings;
                case JTokenType.Float:
                    return jArray.ToObject<float[]>();
                case JTokenType.String:
                    return jArray.ToObject<string[]>();
                case JTokenType.Boolean:
                    return jArray.ToObject<bool[]>();
                case JTokenType.Date:
                    return jArray.ToObject<DateTime[]>();
                case JTokenType.Bytes:
                    return jArray.ToObject<byte[]>();
                case JTokenType.Guid:
                    return jArray.ToObject<Guid[]>();
                case JTokenType.Uri:
                    return jArray.ToObject<Uri[]>();
                case JTokenType.TimeSpan:
                    return jArray.ToObject<TimeSpan[]>();
                default:
                    return jArray;
            }
        }

        private static dynamic ConvertIntegerJToken(JToken jToken)
        {
            var str = jToken.ToObject<string>();

            if (int.TryParse(str, out var i))
                return i;

            if (long.TryParse(str, out var l))
                return l;

            if (ulong.TryParse(str, out var ul))
                return ul;

            return str;
        }
    }
}
