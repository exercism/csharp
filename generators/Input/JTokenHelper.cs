using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Input
{
    public static class JTokenHelper
    {
        public static IEnumerable<JToken> ParentsAndSelf(this JToken jToken)
        {
            while (jToken != null)
            {
                yield return jToken;
                jToken = jToken.Parent;
            }
        }
        
        public static dynamic ConvertJToken(JToken jToken)
        {
            switch (jToken)
            {
                case JObject jObject:
                    return ConvertJObject(jObject);
                case JArray jArray:
                    return ConvertJArray(jArray);
            }

            switch (jToken.Type)
            {
                case JTokenType.Integer:
                    return ConvertJTokenToInteger(jToken);
                case JTokenType.Float:
                    return jToken.ToObject<float>();
                case JTokenType.String:
                    return jToken.ToObject<string>();
                case JTokenType.Boolean:
                    return jToken.ToObject<bool>();
                case JTokenType.Date:
                    return jToken.ToObject<DateTime>();
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

            return new Dictionary<string, dynamic>(properties, StringComparer.OrdinalIgnoreCase);
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
                default:
                    return jArray;
            }
        }

        private static dynamic ConvertJTokenToInteger(JToken jToken)
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