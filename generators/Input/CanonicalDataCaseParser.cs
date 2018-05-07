using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public static class CanonicalDataCaseParser
    {
        private const string TokensPath = "$..*[?(@.property)]";

        public static CanonicalDataCase[] Parse(JArray canonicalDataCasesJArray) 
            => canonicalDataCasesJArray
                .SelectTokens(TokensPath)
                .Select(Parse)
                .ToArray();

        public static CanonicalDataCase Parse(JToken canonicalDataCaseJToken)
        {
            var canonicalDataCase = new CanonicalDataCase();

            canonicalDataCase.Property = canonicalDataCaseJToken.Value<string>("property");
            canonicalDataCase.Description = canonicalDataCaseJToken.Value<string>("description");
            canonicalDataCase.Properties = ToDictionary(canonicalDataCaseJToken);
            canonicalDataCase.Expected = ConvertJToken(canonicalDataCaseJToken["expected"]);
            canonicalDataCase.Input = ToDictionary(canonicalDataCaseJToken["input"]);
            canonicalDataCase.ConstructorInput = new Dictionary<string, dynamic>();
            canonicalDataCase.DescriptionPath = GetDescriptionPath(canonicalDataCaseJToken);

            return canonicalDataCase;
        }

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

        public static IDictionary<string, dynamic> ToDictionary(JToken jToken) => ConvertJToken(jToken);

        public static dynamic ConvertJToken(JToken jToken)
        {
            switch (jToken?.Type)
            {                
                case JTokenType.Object:
                    return ConvertJObject((JObject)jToken);
                case JTokenType.Array:
                    return ConvertJArray((JArray)jToken);
                case JTokenType.Property:
                    return jToken.ToObject<IDictionary<string, dynamic>>();
                case JTokenType.Integer:
                    return jToken.ToObject<int>();
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
                properties[key] = ConvertJToken(properties[key]);
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
                    return jArray.ToObject<int[]>();
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
    }
}
