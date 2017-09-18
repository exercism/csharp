using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Generators.Input
{
    public static class CanonicalDataCaseJson
    {
        public static IDictionary<string, dynamic> ToDictionary(JToken jToken) => ConvertProperty(jToken);
        
        private static dynamic ConvertProperty(dynamic property)
        {
            if (property is JArray jArray)
                return ConvertArrayProperty(property, jArray);

            if (property is JToken jToken)
                return ConvertTokenProperty(jToken);

            return property;
        }

        private static dynamic ConvertTokenProperty(JToken jToken)
        {
            var properties = jToken.ToObject<IDictionary<string, dynamic>>();

            for (var i = 0; i < properties.Count; i++)
            {
                var key = properties.Keys.ElementAt(i);
                properties[key] = ConvertProperty(properties[key]);
            }

            return properties;
        }

        private static dynamic ConvertArrayProperty(dynamic property, JArray jArray)
        {
            // We can't determine the type of the array if the array is empty
            if (!jArray.Any())
                return property;

            // We can only convert when all values have the same type
            if (jArray.Select(x => x.Type).Distinct().Count() != 1)
                return property;

            switch (jArray[0].Type)
            {
                case JTokenType.Object:
                    return jArray.Select(ConvertProperty).ToArray();
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
                    return property;
            }
        }
    }
}
