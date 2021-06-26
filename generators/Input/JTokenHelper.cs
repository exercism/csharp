using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Input
{
    internal static class JTokenHelper
    {
        public static IEnumerable<JToken> ParentsAndSelf(this JToken jToken)
        {
            while (jToken != null)
            {
                yield return jToken;
                jToken = jToken.Parent;
            }
        }
        
        public static dynamic ConvertJToken(JToken jToken) =>
            jToken switch
            {
                JObject jObject => ConvertJObject(jObject),
                JArray jArray => ConvertJArray(jArray),
                _ => jToken.Type switch
                {
                    JTokenType.Integer => ConvertJTokenToInteger(jToken),
                    JTokenType.Float => jToken.ToObject<float>(),
                    JTokenType.String => jToken.ToObject<string>(),
                    JTokenType.Boolean => jToken.ToObject<bool>(),
                    JTokenType.Date => jToken.ToObject<DateTime>(),
                    _ => null
                }
            };

        private static dynamic ConvertJObject(JObject jObject)
        {
            var properties = new Dictionary<string, dynamic>(jObject.Count, StringComparer.OrdinalIgnoreCase);

            foreach (var (key, value) in jObject)
                properties[key] = ConvertJToken(value);

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